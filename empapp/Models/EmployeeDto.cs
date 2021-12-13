using System;
using System.ComponentModel.DataAnnotations;

namespace empapp.Models
{
    public class EmployeeDto
    {
    }

    public record CreateEmployeeDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string EmployeeNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string DateEmployed { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public DateTime ResumptionDate { get; set; }
        [Required]
        public AddSalary SalaryInfo { get; set; }
    }
    public record UpdateEmployeeDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string DateEmployed { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public DateTime ResumptionDate { get; set; }
    }

    public record AddSalary
    {
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? Enddate { get; set; }
    }

    public record PostEmployeeLeave
    {
        [Required]
        public string LeaveType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
