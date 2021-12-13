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
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

      
        /// GET api/<EmployeesController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var emp = await _employeeRepository.GetEmployee(id);
                if (emp is not null)
                    return Ok(new { message = "Employee Fetch Successfully", status = true, EmployeeInfo = emp });
                return BadRequest(new { status = false, message = "Could not identify employee" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       
        /// PUT api/<EmployeesController>/5
        [HttpPost("Leave/{id}")]
        public async Task<IActionResult> Applyleave(int id, [FromBody] PostEmployeeLeave model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var getemployee = await _employeeRepository.GetEmployee(id);
                    if (getemployee is null)
                    {
                        return BadRequest(new { message = "employee leave application failed", status = false, errors = $"Could not find employee by Id {id}" });
                    }

                    var empleave = _mapper.Map<LeaveOfAbsence>(model);
                    empleave.EmployeeNo = getemployee.EmployeeNo;
                    var res = await _employeeRepository.CreateLeave(empleave);
                    if (res is not null)
                        return Ok(new { message = "Employee Leave Application Successful", status = true, EmployeeInfo = res });
                }
                return BadRequest(new { message = "employee update failed", status = false, errors = modelerror() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

         private string modelerror() => string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
    }
}
