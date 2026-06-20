using Microsoft.AspNetCore.Mvc;
using MediCoreHospital.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace MediCoreHospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Registration IDs: 63978, 63969 -> GCN = 1
            // Dashboard Requirements for GCN 1: Doctors on duty, Admissions last 24h

            var today = DateTime.Now;
            var yesterday = today.AddDays(-1);

            var doctorsOnDuty = await _context.Doctors.Where(d => d.IsAvailable).CountAsync();
            var admissionsLast24h = await _context.Admissions
                .Where(a => a.AdmissionDate >= yesterday && a.AdmissionDate <= today)
                .CountAsync();

            ViewBag.DoctorsOnDuty = doctorsOnDuty;
            ViewBag.AdmissionsLast24h = admissionsLast24h;

            var totalPatients = await _context.Patients.CountAsync();
            var totalAdmissions = await _context.Admissions.Where(a => a.Status == Models.AdmissionStatus.Active).CountAsync();

            ViewBag.TotalPatients = totalPatients;
            ViewBag.TotalActiveAdmissions = totalAdmissions;

            var wardOccupancy = await _context.Admissions
                .Where(a => a.Status == Models.AdmissionStatus.Active)
                .GroupBy(a => a.Ward)
                .Select(g => new { Ward = g.Key.ToString(), Count = g.Count() })
                .ToListAsync();

            ViewBag.WardLabels = wardOccupancy.Select(w => w.Ward).ToArray();
            ViewBag.WardCounts = wardOccupancy.Select(w => w.Count).ToArray();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
