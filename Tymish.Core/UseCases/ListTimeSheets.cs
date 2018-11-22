using System.Collections.Generic;
using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IListTimeSheets : IExecutable<object, List<TimeSheet>> {}

    public class ListTimeSheets : BaseUseCase, IListTimeSheets
    {
        public ListTimeSheets(IRepository repository)
            : base(repository) {}

        public List<TimeSheet> Execute(object nullObject = null)
            => _repository.List<TimeSheet>();
    }
}