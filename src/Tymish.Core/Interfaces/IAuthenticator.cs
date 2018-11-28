using System.Threading.Tasks;
using Tymish.Core.DTOs;

namespace Tymish.Core.Interfaces
{
    public interface IAuthenticator<T>
    {
        Task<string> SignIn(LoginDTO user); // returns JWT
        void SignOut(LoginDTO user);
        Task<object> RegisterAdmin(RegisterAdminDTO user);
    }
}