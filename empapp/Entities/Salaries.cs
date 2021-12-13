using System;

namespace empapp.Entities
{
    public class Salaries: BaseEntity
    {
        public string EmployeeNo { get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? Enddate { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee EmployeeInfo { get; set; }
    }
}
