using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IUpdateTimeSheet : IExecutable<TimeSheet, TimeSheet> {}

    public class UpdateTimeSheet : BaseUseCase, IUpdateTimeSheet
    {
        public UpdateTimeSheet(IRepository repository)
            : base(repository) {}
        
        public TimeSheet Execute(TimeSheet timeSheet)
        {
            _repository.Update(timeSheet);
            return timeSheet;
        }
    }
}