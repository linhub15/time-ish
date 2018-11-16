using System.Threading.Tasks;
using Tymish.Core.Entities;

namespace Tymish.Core.Interfaces
{
    public interface IUseCase<TRequest, TResponse>
    {
        TResponse Execute(TRequest obj);
    }
}