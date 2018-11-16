using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IGetTimeSheet : IUseCase<int, TimeSheet> {}

    public class GetTimeSheet : BaseUseCase, IGetTimeSheet
    {
        public GetTimeSheet(IRepository repository)
            : base(repository) {}
        
        public TimeSheet Execute(int TimeSheetId)
            => _repository.Get<TimeSheet>(TimeSheetId);
    }
}