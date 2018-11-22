using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IDeleteEmployee : IExecutable<int, bool> { }

    public class DeleteEmployee : BaseUseCase, IDeleteEmployee
    {
        public DeleteEmployee(Employee employee,
            IRepository repository) : base(repository) { }

        public bool Execute(int id)
        {
            _repository.Delete<Employee>(id);
            return true;
        }
    }
}