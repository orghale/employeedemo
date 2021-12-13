using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empapp.Models
{
    public record AdminDto
    {
        [Required]
        public string EmployeeNo { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RoleId { get; set; }
        [Required]
        public string WorkClass { get; set; }
        public bool IsActive { get; set; }
    }

    public record ChangeAdminPasswordDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public record AdminLoginDto
    {
        public string EmployeeNo { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string WorkClass { get; set; }
        public int UpdateCount { get; set; }
        public bool IsActive { get; set; }
    }
}
