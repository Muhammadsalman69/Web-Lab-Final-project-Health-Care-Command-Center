using System;
using System.ComponentModel.DataAnnotations;

namespace MediCoreHospital.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; }
        
        [Required]
        public string ActionType { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public string PerformedBy { get; set; }
    }
}
