using System.Collections.Generic;

using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IListEmployees : IExecutable<object, List<Employee>> { }

    public class ListEmployees : BaseUseCase, IListEmployees
    {
        public ListEmployees(IRepository repository)
            : base(repository) { }
        
        public List<Employee> Execute(object nullObject)
        {
            return _repository.List<Employee>();
        }
    }
}