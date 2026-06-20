using MediCoreHospital.Data;
using MediCoreHospital.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MediCoreHospital.Services
{
    public interface IBedManagementService
    {
        Task<int?> FindAvailableBedAsync(WardType ward);
        Task LogAuditAsync(string action, string description, string user);
        int GetTotalCapacity(WardType ward);
    }

    public class BedManagementService : IBedManagementService
    {
        private readonly ApplicationDbContext _context;

        public BedManagementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetTotalCapacity(WardType ward)
        {
            return ward switch
            {
                WardType.General => 78,
                WardType.ICU => 69,
                WardType.Maternity => 30,
                WardType.Pediatric => 40,
                _ => 20
            };
        }

        public async Task<int?> FindAvailableBedAsync(WardType ward)
        {
            var capacity = GetTotalCapacity(ward);
            
            // Get all occupied beds in the ward
            var occupiedBeds = await _context.Admissions
                .Where(a => a.Ward == ward && a.Status == AdmissionStatus.Active)
                .Select(a => a.BedNumber)
                .ToListAsync();

            // Find first bed number between 1 and capacity that is not occupied
            var availableBed = Enumerable.Range(1, capacity)
                .FirstOrDefault(b => !occupiedBeds.Contains(b));

            if (availableBed == 0) return null; // No beds available
            return availableBed;
        }

        public async Task LogAuditAsync(string action, string description, string user)
        {
            var log = new AuditLog
            {
                Timestamp = System.DateTime.Now,
                ActionType = action,
                Description = description,
                PerformedBy = user ?? "System"
            };
            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
