using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public class BaseUseCase
    {
        protected IRepository _repository;

        public BaseUseCase(IRepository repository)
        {
            _repository = repository;
        }
    }
}