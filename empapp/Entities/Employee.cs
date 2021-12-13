using System;
using System.Collections.Generic;

namespace empapp.Entities
{
    public class Employee: BaseEntity
    {
        public string FullName { get; set; }
        public DateTime DoB { get; set; }
        public string Gender { get; set; }
        public string EmployeeNo { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string DateEmployed { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }
        public DateTime ResumptionDate { get; set; }
        public virtual List<Salaries> SalaryHistory { get; set; }
        public virtual List<LeaveOfAbsence> LeaveHistory { get; set; }
    }
}
