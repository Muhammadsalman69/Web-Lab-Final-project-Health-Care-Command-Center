using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediCoreHospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDataWithNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActionType = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PerformedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "TEXT", nullable: false),
                    AssignedWard = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    MedicalHistory = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ward = table.Column<int>(type: "INTEGER", nullable: false),
                    BedNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AssignedWard", "FullName", "IsAvailable", "Specialization" },
                values: new object[,]
                {
                    { 1, 1, "Dr. Ali Khan", true, "Pediatrics" },
                    { 2, 2, "Dr. Fatima Rahman", true, "Cardiology" },
                    { 3, 2, "Dr. Tariq Mahmood", true, "Pediatrics" },
                    { 4, 1, "Dr. Aisha Siddiqui", true, "General Medicine" },
                    { 5, 2, "Dr. Omar Farooq", true, "Cardiology" },
                    { 6, 2, "Dr. Zainab Malik", true, "General Medicine" },
                    { 7, 2, "Dr. Muhammad Iqbal", true, "Pediatrics" },
                    { 8, 4, "Dr. Sana Qureshi", true, "Cardiology" },
                    { 9, 4, "Dr. Bilal Ahmed", true, "Pediatrics" },
                    { 10, 2, "Dr. Maryam Shah", false, "General Medicine" },
                    { 11, 1, "Dr. Hasan Raza", false, "Cardiology" },
                    { 12, 1, "Dr. Hira Tariq", false, "General Medicine" },
                    { 13, 4, "Dr. Usman Khalid", true, "Pediatrics" },
                    { 14, 3, "Dr. Nadia Hussain", true, "Cardiology" },
                    { 15, 2, "Dr. Salman Sheikh", false, "Pediatrics" },
                    { 16, 4, "Dr. Zara Abbas", false, "General Medicine" },
                    { 17, 3, "Dr. Ibrahim Syed", true, "Cardiology" },
                    { 18, 3, "Dr. Huda Al-Farsi", true, "General Medicine" },
                    { 19, 4, "Dr. Yusuf Mansour", true, "Pediatrics" },
                    { 20, 4, "Dr. Amina Begum", true, "Cardiology" },
                    { 21, 4, "Dr. Hamza Bukhari", true, "Pediatrics" },
                    { 22, 1, "Dr. Rabia Hassan", true, "General Medicine" },
                    { 23, 3, "Dr. Khalid Mustafa", true, "Cardiology" },
                    { 24, 2, "Dr. Nida Anwar", false, "General Medicine" },
                    { 25, 2, "Dr. Zaid Jamil", true, "Pediatrics" },
                    { 26, 1, "Dr. Farah Hashmi", true, "Cardiology" },
                    { 27, 1, "Dr. Imran Qazi", true, "Pediatrics" },
                    { 28, 1, "Dr. Sadia Rizvi", false, "General Medicine" },
                    { 29, 3, "Dr. Faisal Baig", false, "Cardiology" },
                    { 30, 3, "Dr. Yasmin Javed", false, "General Medicine" },
                    { 31, 4, "Dr. Saad Ansari", false, "Pediatrics" },
                    { 32, 2, "Dr. Saima Latif", false, "Cardiology" },
                    { 33, 2, "Dr. Tariq Najeeb", false, "Pediatrics" },
                    { 34, 2, "Dr. Ayesha Gilani", true, "General Medicine" },
                    { 35, 1, "Dr. Rashid Dar", true, "Cardiology" },
                    { 36, 4, "Dr. Samira Khan", true, "General Medicine" },
                    { 37, 3, "Dr. Nabil Farooq", false, "Pediatrics" },
                    { 38, 2, "Dr. Uzma Aslam", true, "Cardiology" },
                    { 39, 1, "Dr. Kamal Haider", true, "Pediatrics" },
                    { 40, 3, "Dr. Sanaullah Shah", false, "General Medicine" },
                    { 41, 4, "Dr. Asma Chohan", true, "Cardiology" },
                    { 42, 3, "Dr. Jamaluddin", false, "General Medicine" },
                    { 43, 1, "Dr. Shazia Mian", true, "Pediatrics" },
                    { 44, 4, "Dr. Rafiq Zaman", true, "Cardiology" },
                    { 45, 2, "Dr. Mehwish Akram", true, "Pediatrics" },
                    { 46, 2, "Dr. Jamil Khattak", true, "General Medicine" },
                    { 47, 4, "Dr. Ghazala Pervez", true, "Cardiology" },
                    { 48, 2, "Dr. Waqar Younis", true, "General Medicine" },
                    { 49, 2, "Dr. Bushra Iqbal", true, "Pediatrics" },
                    { 50, 2, "Dr. Qasim Zia", true, "Cardiology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Age", "ContactNumber", "FullName", "Gender", "MedicalHistory" },
                values: new object[,]
                {
                    { 1, 14, "0300-5076949", "Ammad", "Male", "History of condition 2" },
                    { 2, 19, "0300-6595096", "Ahmed", "Male", "History of condition 3" },
                    { 3, 71, "0300-4246226", "Ali", "Male", "History of condition 4" },
                    { 4, 19, "0300-7096827", "Omar", "Male", "History of condition 5" },
                    { 5, 21, "0300-2121479", "Tariq", "Male", "History of condition 6" },
                    { 6, 2, "0300-8538605", "Hasan", "Male", "History of condition 7" },
                    { 7, 33, "0300-4388521", "Husain", "Male", "History of condition 8" },
                    { 8, 56, "0300-8039587", "Zaid", "Male", "History of condition 9" },
                    { 9, 28, "0300-6354637", "Bilal", "Male", "History of condition 10" },
                    { 10, 81, "0300-6277229", "Hamza", "Male", "History of condition 11" },
                    { 11, 89, "0300-6473819", "Khalid", "Male", "History of condition 12" },
                    { 12, 44, "0300-6350091", "Yasir", "Male", "History of condition 13" },
                    { 13, 8, "0300-9185307", "Salman", "Male", "History of condition 14" },
                    { 14, 86, "0300-9791846", "Ibrahim", "Male", "History of condition 15" },
                    { 15, 34, "0300-1916861", "Ismail", "Male", "History of condition 16" },
                    { 16, 62, "0300-4966110", "Yusuf", "Male", "History of condition 17" },
                    { 17, 86, "0300-4458671", "Musa", "Male", "History of condition 18" },
                    { 18, 40, "0300-4534086", "Isa", "Male", "History of condition 19" },
                    { 19, 28, "0300-2460738", "Yunus", "Male", "History of condition 20" },
                    { 20, 77, "0300-7279956", "Yahya", "Male", "History of condition 21" },
                    { 21, 30, "0300-2407019", "Zakariya", "Male", "History of condition 22" },
                    { 22, 25, "0300-9283985", "Sulaiman", "Male", "History of condition 23" },
                    { 23, 34, "0300-4694253", "Dawood", "Male", "History of condition 24" },
                    { 24, 65, "0300-1159237", "Ayub", "Male", "History of condition 25" },
                    { 25, 14, "0300-4554590", "Idris", "Male", "History of condition 26" },
                    { 26, 57, "0300-4002335", "Nuh", "Male", "History of condition 27" },
                    { 27, 48, "0300-2016954", "Adam", "Male", "History of condition 28" },
                    { 28, 41, "0300-5394652", "Salih", "Male", "History of condition 29" },
                    { 29, 13, "0300-6032680", "Imran", "Male", "History of condition 30" },
                    { 30, 25, "0300-3704459", "Usman", "Male", "History of condition 31" },
                    { 31, 64, "0300-8342998", "Abu Bakr", "Male", "History of condition 32" },
                    { 32, 67, "0300-1945248", "Rashed", "Male", "History of condition 33" },
                    { 33, 13, "0300-8116753", "Faisal", "Male", "History of condition 34" },
                    { 34, 38, "0300-6686123", "Majid", "Male", "History of condition 35" },
                    { 35, 31, "0300-9716069", "Fahad", "Male", "History of condition 36" },
                    { 36, 26, "0300-5193691", "Saad", "Male", "History of condition 37" },
                    { 37, 65, "0300-6530682", "Saeed", "Male", "History of condition 38" },
                    { 38, 25, "0300-7770003", "Karim", "Male", "History of condition 39" },
                    { 39, 28, "0300-1709603", "Rahim", "Male", "History of condition 40" },
                    { 40, 48, "0300-1655380", "Rahman", "Male", "History of condition 41" },
                    { 41, 22, "0300-1641111", "Amin", "Male", "History of condition 42" },
                    { 42, 85, "0300-6136400", "Jamil", "Male", "History of condition 43" },
                    { 43, 72, "0300-1390702", "Jalal", "Male", "History of condition 44" },
                    { 44, 77, "0300-6237976", "Jamal", "Male", "History of condition 45" },
                    { 45, 84, "0300-5217397", "Kamal", "Male", "History of condition 46" },
                    { 46, 3, "0300-8950639", "Malik", "Male", "History of condition 47" },
                    { 47, 38, "0300-1106954", "Nabil", "Male", "History of condition 48" },
                    { 48, 40, "0300-1422358", "Nasir", "Male", "History of condition 49" },
                    { 49, 16, "0300-3019843", "Qasim", "Male", "History of condition 50" },
                    { 50, 24, "0300-5402258", "Rafiq", "Male", "History of condition 51" },
                    { 51, 54, "0300-7703340", "Fatima", "Female", "History of condition 52" },
                    { 52, 5, "0300-7852392", "Khadija", "Female", "History of condition 53" },
                    { 53, 5, "0300-7186339", "Aisha", "Female", "History of condition 54" },
                    { 54, 35, "0300-1160763", "Maryam", "Female", "History of condition 55" },
                    { 55, 19, "0300-7985097", "Zainab", "Female", "History of condition 56" },
                    { 56, 22, "0300-4373757", "Ruqayyah", "Female", "History of condition 57" },
                    { 57, 69, "0300-1590081", "Umm Kulthum", "Female", "History of condition 58" },
                    { 58, 51, "0300-2804766", "Hafsa", "Female", "History of condition 59" },
                    { 59, 14, "0300-2269435", "Safiyya", "Female", "History of condition 60" },
                    { 60, 88, "0300-7337737", "Maimuna", "Female", "History of condition 61" },
                    { 61, 70, "0300-6045696", "Juwayriya", "Female", "History of condition 62" },
                    { 62, 3, "0300-9559072", "Asma", "Female", "History of condition 63" },
                    { 63, 40, "0300-5105624", "Hind", "Female", "History of condition 64" },
                    { 64, 17, "0300-3436268", "Salma", "Female", "History of condition 65" },
                    { 65, 28, "0300-7089512", "Hawa", "Female", "History of condition 66" },
                    { 66, 81, "0300-1488884", "Sara", "Female", "History of condition 67" },
                    { 67, 72, "0300-8428820", "Hajar", "Female", "History of condition 68" },
                    { 68, 43, "0300-8092501", "Rahma", "Female", "History of condition 69" },
                    { 69, 46, "0300-5370989", "Amina", "Female", "History of condition 70" },
                    { 70, 89, "0300-3350490", "Halima", "Female", "History of condition 71" },
                    { 71, 18, "0300-8113899", "Nadia", "Female", "History of condition 72" },
                    { 72, 24, "0300-1718470", "Laila", "Female", "History of condition 73" },
                    { 73, 57, "0300-6076967", "Yasmin", "Female", "History of condition 74" },
                    { 74, 22, "0300-9625193", "Farah", "Female", "History of condition 75" },
                    { 75, 43, "0300-3029311", "Noor", "Female", "History of condition 76" },
                    { 76, 7, "0300-3731746", "Sana", "Female", "History of condition 77" },
                    { 77, 46, "0300-5217806", "Zara", "Female", "History of condition 78" },
                    { 78, 87, "0300-7364882", "Huda", "Female", "History of condition 79" },
                    { 79, 66, "0300-6823691", "Maha", "Female", "History of condition 80" },
                    { 80, 22, "0300-6392699", "Rania", "Female", "History of condition 81" },
                    { 81, 74, "0300-8022842", "Salwa", "Female", "History of condition 82" },
                    { 82, 42, "0300-7415568", "Mona", "Female", "History of condition 83" },
                    { 83, 42, "0300-2397039", "Safa", "Female", "History of condition 84" },
                    { 84, 24, "0300-4772779", "Samira", "Female", "History of condition 85" },
                    { 85, 65, "0300-9816113", "Tahira", "Female", "History of condition 86" },
                    { 86, 56, "0300-1748625", "Jameela", "Female", "History of condition 87" },
                    { 87, 64, "0300-9057926", "Nabila", "Female", "History of condition 88" },
                    { 88, 33, "0300-2728189", "Nasira", "Female", "History of condition 89" },
                    { 89, 62, "0300-7264084", "Qadira", "Female", "History of condition 90" },
                    { 90, 73, "0300-5188375", "Rafiqa", "Female", "History of condition 91" },
                    { 91, 3, "0300-5353220", "Malika", "Female", "History of condition 92" },
                    { 92, 18, "0300-9667291", "Kamila", "Female", "History of condition 93" },
                    { 93, 88, "0300-1037074", "Latifa", "Female", "History of condition 94" },
                    { 94, 29, "0300-4936251", "Karima", "Female", "History of condition 95" },
                    { 95, 73, "0300-1879918", "Jalila", "Female", "History of condition 96" },
                    { 96, 68, "0300-8434651", "Marwa", "Female", "History of condition 97" },
                    { 97, 2, "0300-9245375", "Amani", "Female", "History of condition 98" },
                    { 98, 86, "0300-2908746", "Amira", "Female", "History of condition 99" },
                    { 99, 55, "0300-5317325", "Bushra", "Female", "History of condition 100" },
                    { 100, 9, "0300-1934433", "Dalia", "Female", "History of condition 101" }
                });

            migrationBuilder.InsertData(
                table: "Admissions",
                columns: new[] { "Id", "AdmissionDate", "BedNumber", "DischargeDate", "DoctorId", "PatientId", "Status", "Ward" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 48, 60, 1, 2 },
                    { 2, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, null, 1, 26, 1, 3 },
                    { 3, new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 14, 2, 3 },
                    { 4, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, 48, 22, 1, 3 },
                    { 5, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 36, 60, 1, 3 },
                    { 6, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 98, 2, 4 },
                    { 7, new DateTime(2026, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, null, 27, 26, 1, 2 },
                    { 8, new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, null, 23, 58, 1, 3 },
                    { 9, new DateTime(2026, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 60, 2, 1 },
                    { 10, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, null, 43, 97, 1, 1 },
                    { 11, new DateTime(2026, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, 40, 11, 1, 1 },
                    { 12, new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 14, 2, 2 },
                    { 13, new DateTime(2026, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 2, 85, 1, 1 },
                    { 14, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null, 17, 77, 1, 3 },
                    { 15, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 33, 2, 4 },
                    { 16, new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, null, 23, 24, 1, 4 },
                    { 17, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, null, 16, 21, 1, 1 },
                    { 18, new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2026, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 38, 2, 2 },
                    { 19, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 41, 33, 1, 3 },
                    { 20, new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, null, 28, 27, 1, 1 },
                    { 21, new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 47, 2, 4 },
                    { 22, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, null, 49, 95, 1, 4 },
                    { 23, new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, null, 4, 77, 1, 3 },
                    { 24, new DateTime(2026, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 31, 2, 2 },
                    { 25, new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 32, 48, 1, 2 },
                    { 26, new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, null, 12, 52, 1, 4 },
                    { 27, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 45, 2, 3 },
                    { 28, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null, 20, 25, 1, 4 },
                    { 29, new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, null, 15, 57, 1, 3 },
                    { 30, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 37, 2, 4 },
                    { 31, new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 13, 38, 1, 2 },
                    { 32, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, null, 18, 82, 1, 2 },
                    { 33, new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 91, 2, 2 },
                    { 34, new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 36, 72, 1, 2 },
                    { 35, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 44, 72, 1, 4 },
                    { 36, new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 45, 2, 1 },
                    { 37, new DateTime(2026, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null, 23, 82, 1, 4 },
                    { 38, new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 38, 21, 1, 2 },
                    { 39, new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 75, 2, 3 },
                    { 40, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, 3, 6, 1, 1 },
                    { 41, new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, 16, 81, 1, 3 },
                    { 42, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 83, 2, 2 },
                    { 43, new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, null, 41, 95, 1, 4 },
                    { 44, new DateTime(2026, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, null, 19, 42, 1, 3 },
                    { 45, new DateTime(2026, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2026, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 98, 2, 4 },
                    { 46, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 31, 50, 1, 3 },
                    { 47, new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 38, 78, 1, 1 },
                    { 48, new DateTime(2026, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2026, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 12, 2, 2 },
                    { 49, new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, null, 20, 14, 1, 2 },
                    { 50, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, null, 35, 39, 1, 3 },
                    { 51, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 28, 2, 4 },
                    { 52, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, null, 50, 28, 1, 3 },
                    { 53, new DateTime(2026, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 5, 18, 1, 1 },
                    { 54, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 75, 2, 2 },
                    { 55, new DateTime(2026, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, null, 32, 99, 1, 1 },
                    { 56, new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, null, 18, 43, 1, 1 },
                    { 57, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 44, 2, 2 },
                    { 58, new DateTime(2026, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, 11, 45, 1, 1 },
                    { 59, new DateTime(2026, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, 15, 31, 1, 4 },
                    { 60, new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 77, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_DoctorId",
                table: "Admissions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientId",
                table: "Admissions",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
