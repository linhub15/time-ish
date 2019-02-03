using Xunit;
using Moq;

using Tymish.Core.Entities;
using Tymish.Core.UseCases;
using Tymish.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Tymish.Infrastructure.DataAccess;

namespace test
{
    public class Employees
    {
        [Fact]
        public void AddEmployee_UseCase()
        {
            Employee employee = new Employee {
                FirstName = "Kazuto",
                LastName = "Kirigaya",
                Email = "Kirito@sao.com",
                HourlyPay = 25
            };

            Employee employeeWithId = employee;
            employeeWithId.Id = 1;

            AddEmployeeResponse response = new AddEmployeeResponse {
                Data = employeeWithId
            };

            var mockAddEmployee = new Mock<IAddEmployee>();

            mockAddEmployee.Setup(m => m.Execute(employee)).Returns(response);

            var result = mockAddEmployee.Object.Execute(employee);

            mockAddEmployee.Verify(e => e.Execute(employee));
            Assert.Equal<Employee>(result.Data, employeeWithId);

        }
    }
}