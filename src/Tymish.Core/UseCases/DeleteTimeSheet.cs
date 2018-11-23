using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IDeleteTimeSheet : IExecutable<int, bool> {}

    public class DeleteTimeSheet : BaseUseCase, IDeleteTimeSheet
    {
        public DeleteTimeSheet(IRepository repository)
            : base(repository) {}

        public bool Execute(int timeSheetId)
        {
            _repository.Delete<TimeSheet>(timeSheetId);
            return true;
        }
    }
}