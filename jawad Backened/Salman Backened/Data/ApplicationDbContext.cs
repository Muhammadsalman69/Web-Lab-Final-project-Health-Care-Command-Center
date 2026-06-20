using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MediCoreHospital.Models;
using System;
using System.Collections.Generic;

namespace MediCoreHospital.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var maleNames = new string[] { "ammad", "Ahmed", "Ali", "Omar", "Tariq", "Hasan", "Husain", "Zaid", "Bilal", "Hamza", "Khalid", "Yasir", "Salman", "Ibrahim", "Ismail", "Yusuf", "Musa", "Isa", "Yunus", "Yahya", "Zakariya", "Sulaiman", "Dawood", "Ayub", "Idris", "Nuh", "Adam", "Salih", "Imran", "Usman", "Abu Bakr", "Rashed", "Faisal", "Majid", "Fahad", "Saad", "Saeed", "Karim", "Rahim", "Rahman", "Amin", "Jamil", "Jalal", "Jamal", "Kamal", "Malik", "Nabil", "Nasir", "Qasim", "Rafiq" };
        var femaleNames = new string[] { "Fatima", "Khadija", "Aisha", "Maryam", "Zainab", "Ruqayyah", "Umm Kulthum", "Hafsa", "Safiyya", "Maimuna", "Juwayriya", "Asma", "Hind", "Salma", "Hawa", "Sara", "Hajar", "Rahma", "Amina", "Halima", "Nadia", "Laila", "Yasmin", "Farah", "Noor", "Sana", "Zara", "Huda", "Maha", "Rania", "Salwa", "Mona", "Safa", "Samira", "Tahira", "Jameela", "Nabila", "Nasira", "Qadira", "Rafiqa", "Malika", "Kamila", "Latifa", "Karima", "Jalila", "Marwa", "Amani", "Amira", "Bushra", "Dalia" };
        
        var doctorNames = new string[] { "Dr. Ali Khan", "Dr. Fatima Rahman", "Dr. Tariq Mahmood", "Dr. Aisha Siddiqui", "Dr. Omar Farooq", "Dr. Zainab Malik", "Dr. Muhammad Iqbal", "Dr. Sana Qureshi", "Dr. Bilal Ahmed", "Dr. Maryam Shah", "Dr. Hasan Raza", "Dr. Hira Tariq", "Dr. Usman Khalid", "Dr. Nadia Hussain", "Dr. Salman Sheikh", "Dr. Zara Abbas", "Dr. Ibrahim Syed", "Dr. Huda Al-Farsi", "Dr. Yusuf Mansour", "Dr. Amina Begum", "Dr. Hamza Bukhari", "Dr. Rabia Hassan", "Dr. Khalid Mustafa", "Dr. Nida Anwar", "Dr. Zaid Jamil", "Dr. Farah Hashmi", "Dr. Imran Qazi", "Dr. Sadia Rizvi", "Dr. Faisal Baig", "Dr. Yasmin Javed", "Dr. Saad Ansari", "Dr. Saima Latif", "Dr. Tariq Najeeb", "Dr. Ayesha Gilani", "Dr. Rashid Dar", "Dr. Samira Khan", "Dr. Nabil Farooq", "Dr. Uzma Aslam", "Dr. Kamal Haider", "Dr. Sanaullah Shah", "Dr. Asma Chohan", "Dr. Jamaluddin", "Dr. Shazia Mian", "Dr. Rafiq Zaman", "Dr. Mehwish Akram", "Dr. Jamil Khattak", "Dr. Ghazala Pervez", "Dr. Waqar Younis", "Dr. Bushra Iqbal", "Dr. Qasim Zia" };

        var patients = new List<Patient>();
        var random = new Random(63978);
        int patientId = 1;

        // Seed Male Patients
        foreach (var name in maleNames)
        {
            patients.Add(new Patient
            {
                Id = patientId++,
                FullName = name.Substring(0, 1).ToUpper() + name.Substring(1), // capitalize first letter
                ContactNumber = $"0300-{random.Next(1000000, 9999999)}",
                Age = random.Next(1, 90),
                Gender = "Male",
                MedicalHistory = $"History of condition {patientId}"
            });
        }

        // Seed Female Patients
        foreach (var name in femaleNames)
        {
            patients.Add(new Patient
            {
                Id = patientId++,
                FullName = name,
                ContactNumber = $"0300-{random.Next(1000000, 9999999)}",
                Age = random.Next(1, 90),
                Gender = "Female",
                MedicalHistory = $"History of condition {patientId}"
            });
        }
        modelBuilder.Entity<Patient>().HasData(patients);

        var doctors = new List<Doctor>();
        int doctorId = 1;
        foreach (var name in doctorNames)
        {
            doctors.Add(new Doctor
            {
                Id = doctorId++,
                FullName = name,
                Specialization = doctorId % 3 == 0 ? "Cardiology" : (doctorId % 2 == 0 ? "Pediatrics" : "General Medicine"),
                AssignedWard = (WardType)(random.Next(1, 5)),
                IsAvailable = random.Next(0, 10) > 2 // 80% available
            });
        }
        modelBuilder.Entity<Doctor>().HasData(doctors);

        var admissions = new List<Admission>();
        var baseDate = new DateTime(2026, 6, 1);
        for (int i = 1; i <= 60; i++)
        {
            var admDate = baseDate.AddDays(-random.Next(1, 30));
            bool isDischarged = i % 3 == 0;
            admissions.Add(new Admission
            {
                Id = i,
                PatientId = random.Next(1, 101),
                DoctorId = random.Next(1, 51),
                Ward = (WardType)(random.Next(1, 5)),
                BedNumber = random.Next(1, 20),
                AdmissionDate = admDate,
                DischargeDate = isDischarged ? admDate.AddDays(random.Next(1, 10)) : null,
                Status = isDischarged ? AdmissionStatus.Discharged : AdmissionStatus.Active
            });
        }
        modelBuilder.Entity<Admission>().HasData(admissions);
    }
}
