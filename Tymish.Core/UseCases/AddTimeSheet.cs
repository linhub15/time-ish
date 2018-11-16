using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IAddTimeSheet : IUseCase<TimeSheet, TimeSheet> { }

    public class AddTimeSheet : BaseUseCase, IAddTimeSheet
    {
        public AddTimeSheet(IRepository repository) 
            : base(repository) { }

        public TimeSheet Execute(TimeSheet timeSheet)
            => _repository.Add<TimeSheet>(timeSheet);
    }
}