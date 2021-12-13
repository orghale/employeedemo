using System;
using System.Collections.Generic;

namespace empapp.Entities
{
    public class Admin : BaseEntity
    {       
        public string EmployeeNo { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string WorkClass { get; set; }
        public string PasswordHistory { get; set; }
        public string Password { get; set; }
        public int UpdateCount { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee EmployeeInfo { get; set; }
    }
}
