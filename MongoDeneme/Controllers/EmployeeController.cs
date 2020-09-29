using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDeneme.Model;

namespace MongoDeneme.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeService.GetEmployees();
            if (result == null)
            {
                return new StatusCodeResult(404);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _employeeService.GetById(id);
            if (result == null)
            {
                return new StatusCodeResult(404);
            }

            return Ok(result);
        }
    }
}