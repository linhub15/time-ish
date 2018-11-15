using api.Core.Entities;
using api.Core.Interfaces;

namespace api.Core.UseCases
{
    public interface IAddEmployee : IUseCase<Employee, int> {  }
    public class AddEmployee : IAddEmployee
    {
        private IEmployeeRepository _employeeRepository;
        public AddEmployee(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public int Execute(Employee entity)
        {
            return _employeeRepository.Add(entity);
        }
    }
}