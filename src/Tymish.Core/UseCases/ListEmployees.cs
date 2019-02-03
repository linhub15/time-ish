using System.Collections.Generic;
using System.Linq;
using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IListEmployees : IExecutable<object, IQueryable<Employee>> { }

    public class ListEmployees : BaseUseCase, IListEmployees
    {
        public ListEmployees(IRepository repository)
            : base(repository) { }
        
        public IQueryable<Employee> Execute(object nullObject)
        {
            return _repository.List<Employee>();
        }
    }
}