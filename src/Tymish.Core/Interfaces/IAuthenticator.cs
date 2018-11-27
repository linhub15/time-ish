using System.Threading.Tasks;
using Tymish.Core.DTOs;

namespace Tymish.Core.Interfaces
{
    public interface IAuthenticator<T>
    {
        Task<object> SignIn(LoginDTO user);
        void SignOut(LoginDTO user);
        Task<object> RegisterAdmin(RegisterAdminDTO user);
    }
}