using System.Collections.Generic;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TimeishContext _context;
        public EmployeesController(TimeishContext context) 
        {
            _context = context;
        }

        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return null;
        }
    }
}