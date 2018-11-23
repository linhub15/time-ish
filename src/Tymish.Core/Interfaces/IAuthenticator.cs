using Tymish.Core.DTOs;

namespace Tymish.Core.Interfaces
{
    public interface IAuthenticator<T>
    {
        string Login(LoginDTO user);
        void Logout(LoginDTO user);
        T RegisterUser(T user);
    }
}