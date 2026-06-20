using System.ComponentModel.DataAnnotations;

namespace MediCoreHospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [Display(Name = "Assigned Ward")]
        public WardType AssignedWard { get; set; }

        [Required]
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }
    }
}
