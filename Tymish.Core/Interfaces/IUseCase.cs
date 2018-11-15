using System.Threading.Tasks;

namespace Tymish.Core.Interfaces
{
    public interface IUseCase<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}