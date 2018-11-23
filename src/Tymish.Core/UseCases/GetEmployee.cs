using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IGetEmployee : IExecutable<int, Employee> { }
    
    public class GetEmployee : BaseUseCase, IGetEmployee
    {
        public GetEmployee(IRepository repository) 
            : base(repository) { }

        public Employee Execute(int id)
        {
            return _repository.Get<Employee>(id);
        }
    }
}