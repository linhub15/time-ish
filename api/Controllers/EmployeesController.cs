using System.Collections.Generic;
using System.Linq;
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
            return _context.Employees;
        }

        // GET api/employees/:id
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return _context.Employees
                .SingleOrDefault(employee => employee.Id == id);
        }

        // POST api/employees
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        // PUT api/employees/:id
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            employee.Id = id;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }

        // DELETE /api/employees/:id
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            var Employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            _context.Employees.Remove(Employee);
            _context.SaveChanges();
        }
    }
}