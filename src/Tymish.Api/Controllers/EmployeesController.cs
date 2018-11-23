using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Tymish.Core.Entities;
using Tymish.Core.UseCases;
using Tymish.Infrastructure.DataAccess;

namespace Tymish.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGetEmployee _getEmployee;
        private readonly IListEmployees _listEmployees;
        private readonly IAddEmployee _addEmpoloyee;
        private readonly IUpdateEmployee _updateEmployee;
        private readonly IDeleteEmployee _deleteEmployee;

        public EmployeesController(
            IGetEmployee getEmployee,
            IListEmployees listEmployees,
            IAddEmployee addEmployee,
            IUpdateEmployee updateEmployee,
            IDeleteEmployee deleteEmployee) 
        {
            _getEmployee = getEmployee;
            _listEmployees = listEmployees;
            _addEmpoloyee = addEmployee;
            _updateEmployee = updateEmployee;
            _deleteEmployee = deleteEmployee;
        }

        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _listEmployees.Execute(null);
        }

        // GET api/employees/:id
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return _getEmployee.Execute(id);
        }

        // POST api/employees
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            TryValidateModel(employee);
            return _addEmpoloyee.Execute(employee).Data;
        }

        // PUT api/employees/:id
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            employee.Id = id;
            TryValidateModel(employee);
            _updateEmployee.Execute(employee);
            return employee;
        }

        // DELETE api/employees/:id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            _deleteEmployee.Execute(id);
            return Ok();
        }
    }
}