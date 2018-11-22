using System.Threading.Tasks;
using Tymish.Core.Entities;

namespace Tymish.Core.Interfaces
{
    public interface IExecutable<TRequest, TResponse>
    {
        TResponse Execute(TRequest obj);
    }
}