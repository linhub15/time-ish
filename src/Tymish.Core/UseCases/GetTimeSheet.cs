using System.Linq;
using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IGetTimeSheet : IExecutable<int, TimeSheet> {}

    public class GetTimeSheet : BaseUseCase, IGetTimeSheet
    {
        public GetTimeSheet(IRepository repository)
            : base(repository) {}
        
        public TimeSheet Execute(int TimeSheetId)
        {
            return _repository.List<TimeSheet>()
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
                })
                .SingleOrDefault(t => t.Id == TimeSheetId);
        }
    }
}