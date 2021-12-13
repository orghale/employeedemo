using System;

namespace empapp.Entities
{
    public class LeaveOfAbsence: BaseEntity
    {
        public string EmployeeNo { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public virtual Employee EmployeeInfo { get; set; }
    }
}
