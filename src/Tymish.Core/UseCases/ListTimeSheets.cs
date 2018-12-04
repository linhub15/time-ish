using System.Collections.Generic;
using System.Linq;
using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IListTimeSheets : IExecutable<object, IQueryable<TimeSheet>> {}

    public class ListTimeSheets : BaseUseCase, IListTimeSheets
    {
        public ListTimeSheets(IRepository repository)
            : base(repository) {}

        public IQueryable<TimeSheet> Execute(object nullObject = null)
            => _repository.List<TimeSheet>()
                .Select(t => new TimeSheet
                {
                    Id = t.Id,
                    Issued = t.Issued,
                    Submitted = t.Submitted,
                    Approved = t.Approved,
                    EmployeeId = t.EmployeeId,
                    PayPeriodId = t.PayPeriodId,
                    Activities = t.Activities
                        .AsQueryable()
                        .ToList(),
                    Employee = t.Employee,
                    PayPeriod = t.PayPeriod
                });
    }
}