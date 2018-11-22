using System.Collections.Generic;

namespace Tymish.Core.Interfaces
{
    public interface IUseCaseResponse<T>
    {
        bool Success {get;}
        T Data {get; set;}
        List<string> Errors {get;}

        void MarkSuccessful();
        void AddError(string error);
    }
}