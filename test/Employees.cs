using Xunit;
using Moq;

using Tymish.Core.Entities;
using Tymish.Core.UseCases;
using Tymish.Core.Interfaces;

namespace test
{
    public class Employees
    {
        [Fact]
        public void CanAddEmployee(
            IAddEmployee addEmployee, IRepository repository)
        {
        //Given an employee
        Employee employee = new Employee {
            FirstName = "Kazuto",
            LastName = "Kirigaya",
            Email = "Kirito@sao.com",
            HourlyPay = 25
        };
        //When adding employee
        addEmployee.Execute(employee);

        //Then
        Assert.True(employee.Id != 0);
        }
    }
}