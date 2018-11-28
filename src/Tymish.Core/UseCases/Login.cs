using Tymish.Core.DTOs;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface ILogin : IExecutable<LoginDTO, string>{}

    public class Login : BaseUseCase, ILogin
    {
        private readonly IAuthenticator<LoginDTO> _authenticator;

        public Login(IRepository repository, IAuthenticator<LoginDTO> authenticator)
            : base(repository)
        {
            _authenticator = authenticator;
        }

        public string Execute(LoginDTO userCredentials)
        {
            string JwtToken = _authenticator.SignIn(userCredentials).Result;
            return JwtToken;
        }
    }
}