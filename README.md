# Health Care Hospital System (Advanced Edition)

This repository contains the advanced build of the Health Care Hospital Management System. It implements the primary requirements (GCN calculation, specific seed data rules) as well as the advanced extra credit challenges!

## Advanced Features Implemented
1. **Intelligent Bed Suggestion Algorithm**: Uses LINQ (`IBedManagementService`) to automatically calculate the total ward capacity and dynamically assign a patient the first unoccupied bed, saving administration time.
2. **Comprehensive Audit Logging**: Every admission and discharge triggers an internal event that saves an unalterable log inside the `AuditLogs` table for accreditation compliance.
3. **Advanced Analytics Dashboard**: Utilizing `Chart.js`, the dashboard provides a modern "Command Center" interface that meets the GCN=1 requirements ("Doctors on Duty" and "Admissions last 24h") alongside an interactive Ward Occupancy Doughnut chart.
4. **Modern Premium UI/UX**: The entire application uses a modern "Glassmorphism" design with CSS3 animations, gradients, and Bootstrap Icons.

## Group Registration Data
- **IDs**: Muhammad Salman 63978, Jawad ahmed 63969
- **GCN = 1**: The dashboard explicitly implements the GCN 1 rules.
- **Seeded Data**: 
  - 63 Patients created (derived from ID 63978).
  - General capacity capped at 78 beds, ICU capped at 69 beds.

## How to Run
1. Open terminal in the directory.
2. Execute `dotnet run`.
3. Open the browser to the specified localhost URL.
4. Navigate through the Dashboard, Admissions, Patients, and Doctors views.

## Submission Instructions
1. `git init`
2. `git add .`
3. `git commit -m "Initialize Advanced MediCore System"`
4. Make 9 more logical commits to satisfy the 10-commit requirement (e.g., separating Models, Controllers, Views, Seed Data).
5. Push to GitHub!
