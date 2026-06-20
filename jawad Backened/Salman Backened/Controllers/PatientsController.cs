using Microsoft.AspNetCore.Mvc;
using MediCoreHospital.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MediCoreHospital.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.OrderBy(p => p.FullName).ToListAsync());
        }
    }
}
