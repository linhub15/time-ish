using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IUpdateEmployee : IExecutable<Employee, bool> { }

    public class UpdateEmployee : BaseUseCase, IUpdateEmployee
    {
        public UpdateEmployee(IRepository repository) 
            : base(repository) {}

        public bool Execute(Employee employee)
        {
            _repository.Update<Employee>(employee);
            return true;
        }
    }
}