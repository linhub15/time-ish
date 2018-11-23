using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public class Login : BaseUseCase
    {
        public Login(IRepository repository)
            : base(repository) {}

        public void Execute(LoginDTO userCredentials)
        {
            // TODO
        }
    }
}