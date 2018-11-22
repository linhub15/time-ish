using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IUpdateTimeSheet : IExecutable<TimeSheet, bool> {}

    public class UpdateTimeSheet : BaseUseCase, IUpdateTimeSheet
    {
        public UpdateTimeSheet(IRepository repository)
            : base(repository) {}
        
        public bool Execute(TimeSheet timeSheet)
        {
            _repository.Update(timeSheet);
            return true;
        }
    }
}