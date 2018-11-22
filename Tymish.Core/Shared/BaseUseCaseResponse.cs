using System.Collections.Generic;
using Tymish.Core.Interfaces;

namespace Tymish.Core.Shared
{
    public class BaseUseCaseResponse<T> : IUseCaseResponse<T>
    {
        public bool Success {get; private set;}
        public T Data {get; set;}
        public List<string> Errors {get; private set;}

        public BaseUseCaseResponse()
        {
            Success = false;
            Errors = new List<string>();
        }

        public void MarkSuccessful()
            => this.Success = true;

        public void AddError(string error)
            => this.Errors.Add(error);
    }
}