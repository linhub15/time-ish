using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IAddEmployee : IUseCase<Employee, Employee> { }
    
    public class AddEmployee : BaseUseCase, IAddEmployee
    {
        public AddEmployee(IRepository repository) 
            : base(repository) { }

        public Employee Execute(Employee employee)
        {
            return _repository.Add<Employee>(employee);
        }
    }
}