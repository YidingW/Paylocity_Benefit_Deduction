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
    public class DependantController : Controller
    {

        private readonly ILogger<DependantController> _logger;
        private readonly IDependantDataService _dependantDataService;

        public DependantController(ILogger<DependantController> logger, IDependantDataService dataService)
        {
            _logger = logger;
            _dependantDataService = dataService;
        }

        [HttpPost]
        public async Task<IActionResult> NewDependant(Dependant dependant)
        {
            await _dependantDataService.AddDependant(dependant);
            return Ok();
        }
    }
}