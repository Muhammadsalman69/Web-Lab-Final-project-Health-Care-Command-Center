# MediCore City Hospital - Project Documentation

## 1. Group Configuration Number (GCN) Calculation
Before starting development, the Group Configuration Number was calculated based on our registration IDs.
* **Assumed Registration IDs:** `63978` and `63969`
* **Summation of Digits:**
  * Member 1 (`63978`): `6 + 3 + 9 + 7 + 8 = 33`
  * Member 2 (`63969`): `6 + 3 + 9 + 6 + 9 = 33`
  * Total Sum = `66`
* **GCN Calculation:** `66 % 5 = 1`
* **Final GCN:** **1**

### Dashboard Implication (GCN = 1)
According to the project instructions, a GCN of 1 requires the dashboard to display:
1. **Doctors currently on duty**
2. **Admissions made during the last 24 hours**

**Implementation:** Both of these metrics are actively queried via Entity Framework Core inside `HomeController.cs` and are prominently displayed as the main statistic cards on the frontend dashboard.

---

## 2. Registration-Number Based Assumptions
The requirements mandated that at least one dashboard component must derive its displayed values directly from the registration numbers.

* **Derived Value:** Total Hospital Bed Capacity
* **Logic:** We extracted the last two digits of both registration numbers (`78` and `69`). The sum (`78 + 69 = 147`) represents the absolute maximum bed capacity for the hospital.
* **Dashboard Component:** A live "Available Beds" counter was added beneath the "New Admission" button on the dashboard. It dynamically calculates `147 - (Total Active Admissions)` to provide real-time availability.

---

## 3. Architectural Decisions
* **Framework & Pattern:** ASP.NET Core MVC was chosen as the architecture. The Models represent the data schema, the Views handle the HTML/Razor UI, and the Controllers manage the business logic and database querying.
* **Database & ORM:** We utilized Entity Framework Core (EF Core) to map C# object-oriented models to the relational database. For local development simplicity and ease of submission, SQLite (`app.db`) is used as the underlying data store, replacing a heavy SQL Server instance while maintaining identical LINQ querying capabilities.
* **Styling & UI:** We incorporated Bootstrap 5, custom Glassmorphism CSS styling (`site.css`), and dynamic charts (`Chart.js`) to ensure the application looks premium and modern.

---

## 4. Bed Management Mechanism & Assumptions
* **Bed Allocation Strategy:** Beds are not treated as independent entities in the database. Instead, bed occupancy is derived dynamically through LINQ queries executed against the `Admissions` table where `Status == Active`.
* **Intelligent Assignment:** When a patient is admitted, they are assigned to a specific ward (General, ICU, Maternity, Pediatric). The dashboard visualizes real-time load distribution among wards using a doughnut chart.
* **Audit Logging:** An `AuditLogs` table was created to maintain a history of actions, prioritizing accountability and tracking when admissions are created or discharged.

---

## 5. Feature Prioritization & Justification
Balancing development speed with correctness, our team prioritized:
1. **Accurate Dashboard Metrics:** Ensuring the GCN-specific metrics (Doctors on duty, Admissions 24h) were computationally accurate using LINQ `CountAsync()`.
2. **User Experience (UX):** Rather than presenting a collection of disconnected CRUD pages, we built an "Advanced Command Center" that a hospital administrator could realistically use immediately upon deployment. All metric cards were made clickable to provide intuitive navigation to the respective CRUD views.
3. **Data Integrity over Algorithm Complexity:** We opted for dynamic bed counting via LINQ rather than storing redundant state variables. This ensures inconsistent bed availability calculations do not negatively impact patient care.
