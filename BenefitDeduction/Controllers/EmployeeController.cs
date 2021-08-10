using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BenefitDeduction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeDataService _employeeDataService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeDataService dataService)
        {
            _logger = logger;
            _employeeDataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeDataService.GetAllEmployees());
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeDataService.GetEmployee(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> NewEmployee(Employee employee)
        {
            await _employeeDataService.NewEmployee(employee);
            return Ok();
        }
    }
}