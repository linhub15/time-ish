using Tymish.Core.DTOs;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public class RegisterAdmin : BaseUseCase
    {
        public RegisterAdmin(IRepository repository)
            : base(repository) {}

        public void Execute(RegisterAdminDTO admin)
        {
            // TODO
        }
    }
}