using empapp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empapp.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(ApplicationDbContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Employee> CreateEmployee(Employee emp)
        {
            try
            {
                emp.EmployeeNo = $"EMP{_context.Employees.Count() + 1}";
                _context.Employees.Add(emp);
                await _context.SaveChangesAsync();
                return emp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create employee failed");
                throw;
            }
        }

        public async Task<Employee> UpdateEmployee(Employee emp)
        {
            try
            {
                if (emp == null)
                    return null;
                _context.Entry(emp).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return emp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update Employee Failed");
                throw;
            }
        }

       public async Task<Admin> UpdateAdmin(Admin admin)
        {
            try
            {
                if (admin == null)
                    return null;
                _context.Entry(admin).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return admin;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update Admin password Failed");
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(Employee emp)
        {
            try
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete Employee Failed");
                throw;
            }
        }

        public async Task<List<Employee>> FetchEmployees(int page = 1, int pageSize = 20)
        {
            try
            {
                var offset = (page - 1) * pageSize;
                var limit = pageSize * page;
                return await _context.Employees.Skip(offset).Take(limit).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FetchEmployees");
                throw;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
#pragma warning disable CS8603 // Possible null reference return.
                return await _context.Employees.Include(s => s.SalaryHistory).Include(l => l.LeaveHistory).Where(x => x.Id == id).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEmployee");
                throw;
            }
        }

        public async Task<Employee> GetEmployeeByEmployeeNo(string employeeNo)
        {
            try
            {
                return await _context.Employees.Where(x => x.EmployeeNo == employeeNo).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEmployeeByEmployeeNo");
                throw;
            }
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            try
            {
                return await _context.Employees.Where(x => x.Email == email).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEmployeeByEmail");
                throw;
            }
        }

        public async Task<Admin> GetAdmin(string email, string oldPassword)
        {
            try
            {
                return await _context.Admin.Where(x => x.Email == email && x.Password == oldPassword).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAdmin");
                throw;
            }
        }

        public async Task<LeaveOfAbsence> CreateLeave(LeaveOfAbsence leaveOfAbsence)
        {
            try
            {
                _context.LeaveOfAbsences.Add(leaveOfAbsence);
                await _context.SaveChangesAsync();
                return leaveOfAbsence;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create employee leave");
                throw;
            }
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            try
            {
                _context.Admin.Add(admin);
                await _context.SaveChangesAsync();
                return admin;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create Admin error");
                throw;
            }
        }
    }
}
