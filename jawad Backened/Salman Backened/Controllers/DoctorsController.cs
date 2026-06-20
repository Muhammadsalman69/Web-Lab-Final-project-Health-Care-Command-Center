using Microsoft.AspNetCore.Mvc;
using MediCoreHospital.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MediCoreHospital.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.OrderBy(d => d.FullName).ToListAsync());
        }
    }
}
