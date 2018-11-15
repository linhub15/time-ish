using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IAddEmployee : IUseCase<Employee, Employee> {  }
    
    public class AddEmployee : IAddEmployee
    {
        private IRepository _employeeRepository;

        public AddEmployee(IRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Execute(Employee entity)
        {
            return _employeeRepository.Add<Employee>(entity);
        }
    }
}