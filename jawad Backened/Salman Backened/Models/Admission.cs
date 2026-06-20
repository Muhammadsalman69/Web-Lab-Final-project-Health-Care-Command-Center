using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediCoreHospital.Models
{
    public class Admission
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [Required]
        public WardType Ward { get; set; }

        [Required]
        public int BedNumber { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }

        [Required]
        public AdmissionStatus Status { get; set; }
    }
}
