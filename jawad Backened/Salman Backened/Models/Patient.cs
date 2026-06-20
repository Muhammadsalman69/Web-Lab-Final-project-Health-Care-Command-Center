using System.ComponentModel.DataAnnotations;

namespace MediCoreHospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        
        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        
        [Required]
        [Range(0, 150)]
        public int Age { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        [Display(Name = "Medical History")]
        public string MedicalHistory { get; set; }
    }
}
