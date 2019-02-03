using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IDeleteActivity : IExecutable<int, bool> {}

    public class DeleteActivity : BaseUseCase, IDeleteActivity
    {
        public DeleteActivity(IRepository repository) 
            : base(repository) {}

        public bool Execute(int activityId)
        {
            _repository.Delete<Activity>(activityId);
            return true;
        }
    }
}