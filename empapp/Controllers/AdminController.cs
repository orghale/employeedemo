using AutoMapper;
using empapp.Entities;
using empapp.Infrastructure;
using empapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace empapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiSecurity]

    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public AdminController(ILogger<AdminController> logger, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        /// POST api/<AdminController>
        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var getemployee = await _employeeRepository.GetEmployeeByEmployeeNo(model.EmployeeNo);
                    if (getemployee is null)
                    {
                        return BadRequest(new { message = "Admin creation failed", status = false, errors = $"Could not find employee {model.EmployeeNo}" });
                    }

                    var admin = _mapper.Map<Admin>(model);
                    admin.PasswordHistory = $"^==^UpdateCount:{0}/Date:{DateTime.UtcNow}/Password:{model.Password}";
                    admin.Email = getemployee.Email;
                    var res = await _employeeRepository.CreateAdmin(admin);
                    if (res is not null)
                        return Ok(new { message = "Admin creation Successful", status = true, EmployeeInfo = res });
                }
                return BadRequest(new { message = "Admin creation failed", status = false, errors = modelerror() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// GET api/<AdminController>/5
        [HttpGet("AdminLogin/{Email}")]
        public async Task<IActionResult> Login(string Email, [FromQuery] string Password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var getAdmin = await _employeeRepository.GetAdmin(Email, Password);
                    if (getAdmin is null)
                    {
                        return BadRequest(new { message = "Admin login failed", status = false, errors = $"Invalid Email/Password {Email}" });
                    }
                                       
                    var admin = _mapper.Map<AdminLoginDto>(getAdmin);

                    return Ok(new { message = "Admin password Updated Successfully", status = true, AdminInfo = admin });
                }
                return BadRequest(new { message = "Admin password update failed", status = false, errors = modelerror() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

      /// PUT api/<AdminController>/5
        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] ChangeAdminPasswordDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var getAdmin = await _employeeRepository.GetAdmin(model.Email, model.OldPassword);
                    if (getAdmin is null)
                    {
                        return BadRequest(new { message = "Admin password update failed", status = false, errors = $"Could not find admin {model.Email}" });
                    }

                    var admin = _mapper.Map<Admin>(model);
                    admin.Email = getAdmin.Email;
                    admin.UpdateCount = getAdmin.UpdateCount++;
                    admin.PasswordHistory = $"{getAdmin.PasswordHistory}^==^UpdateCount:{getAdmin.UpdateCount}/Date:{DateTime.UtcNow}/Password:{getAdmin.Password}";

                    var res = await _employeeRepository.UpdateAdmin(admin);
                    if (res is not null)
                        return Ok(new { message = "Admin password Updated Successfully", status = true, Email = res.Email });
                }
                return BadRequest(new { message = "Admin password update failed", status = false, errors = modelerror() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// POST api/<AdminController>
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = _mapper.Map<Employee>(model);
                    var salinfo = _mapper.Map<Salaries>(model.SalaryInfo);

                    emp.SalaryHistory?.Add(salinfo);
                    var res = await _employeeRepository.CreateEmployee(emp);
                    if (res is not null)
                        return Ok(new { message = "Employee Created Successfully", status = true, EmployeeInfo = res });
                }
                return BadRequest(new { message = "employee creation failed", status = false, errors = modelerror() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// PUT api/<AdminController>/5
        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var getemployee = await _employeeRepository.GetEmployee(id);
                    if (getemployee is null)
                    {
                        return BadRequest(new { message = "employee update failed", status = false, errors = $"Could not find employee by Id {id}" });
                    }

                    var emp = _mapper.Map(model, getemployee);
                    var res = await _employeeRepository.UpdateEmployee(emp);
                    if (res is not null)
                        return Ok(new { message = "Employee Updated Successfully", status = true, EmployeeInfo = res });
                }
                return BadRequest(new { message = "employee update failed", status = false, errors = modelerror() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// GET api/<AdminController>/5/5
        [HttpGet("FetchEmployees")]
        public async Task<IActionResult> GetEmployees([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var emps = await _employeeRepository.FetchEmployees(pageNumber, pageSize);
                if (emps is not null)
                    return Ok(new { message = "Employee Fetch Successfully", status = true, EmployeeInfo = emps });
                return BadRequest(new { status = false, message = "Could not fetch employees" });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        /// DELETE api/<AdminController>/5
        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var getemployee = await _employeeRepository.GetEmployee(id);
                if (getemployee is null)
                {
                    return BadRequest(new { message = "employee update failed", status = false, errors = $"Could not find employee by Id {id}" });
                }

                var deleteemp = await _employeeRepository.DeleteEmployee(getemployee);
                if (deleteemp)
                    return Ok(new { message = "employee deleted successfully", status = true });
                return BadRequest(new { message = "employee delete failed", status = false, });

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
       
        private string modelerror() => string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
    }
}
