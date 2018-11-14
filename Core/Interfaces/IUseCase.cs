using System.Threading.Tasks;

namespace api.Core.Interfaces
{
    public interface IUseCase<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}