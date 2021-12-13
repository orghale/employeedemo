using empapp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empapp.Infrastructure
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee emp);

        Task<Employee> UpdateEmployee(Employee emp);

        Task<Admin> UpdateAdmin(Admin admin);

        Task<bool> DeleteEmployee(Employee emp);

        Task<List<Employee>> FetchEmployees(int page, int pageSize);

        Task<Employee> GetEmployee(int id);

        Task<Employee> GetEmployeeByEmployeeNo(string employeeNo);

        Task<Employee> GetEmployeeByEmail(string email);

        Task<Admin> GetAdmin(string email, string oldPassword);
        Task<LeaveOfAbsence> CreateLeave(LeaveOfAbsence leaveOfAbsence);

        Task<Admin> CreateAdmin(Admin admin);
    }
}
