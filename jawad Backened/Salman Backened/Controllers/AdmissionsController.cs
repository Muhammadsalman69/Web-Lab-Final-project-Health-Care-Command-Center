using Microsoft.AspNetCore.Mvc;
using MediCoreHospital.Data;
using MediCoreHospital.Models;
using MediCoreHospital.Services;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediCoreHospital.Controllers
{
    public class AdmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBedManagementService _bedService;

        public AdmissionsController(ApplicationDbContext context, IBedManagementService bedService)
        {
            _context = context;
            _bedService = bedService;
        }

        public async Task<IActionResult> Index()
        {
            var admissions = await _context.Admissions
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .OrderByDescending(a => a.AdmissionDate)
                .ToListAsync();
            return View(admissions);
        }

        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            ViewData["DoctorId"] = new SelectList(_context.Doctors.Where(d => d.IsAvailable), "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,DoctorId,Ward")] Admission admission)
        {
            var availableBed = await _bedService.FindAvailableBedAsync(admission.Ward);
            
            if (availableBed == null)
            {
                ModelState.AddModelError("Ward", $"No available beds in the {admission.Ward} ward.");
                ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", admission.PatientId);
                ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "FullName", admission.DoctorId);
                return View(admission);
            }

            admission.BedNumber = availableBed.Value;
            admission.AdmissionDate = System.DateTime.Now;
            admission.Status = AdmissionStatus.Active;

            _context.Add(admission);
            await _context.SaveChangesAsync();

            var patientName = (await _context.Patients.FindAsync(admission.PatientId))?.FullName;
            await _bedService.LogAuditAsync("ADMISSION", $"Patient {patientName} admitted to {admission.Ward} bed {admission.BedNumber}.", User.Identity?.Name);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Discharge(int id)
        {
            var admission = await _context.Admissions.Include(a => a.Patient).FirstOrDefaultAsync(a => a.Id == id);
            if (admission == null || admission.Status != AdmissionStatus.Active) return NotFound();

            admission.Status = AdmissionStatus.Discharged;
            admission.DischargeDate = System.DateTime.Now;
            _context.Update(admission);
            await _context.SaveChangesAsync();

            await _bedService.LogAuditAsync("DISCHARGE", $"Patient {admission.Patient.FullName} discharged from {admission.Ward} bed {admission.BedNumber}.", User.Identity?.Name);

            return RedirectToAction(nameof(Index));
        }
    }
}
