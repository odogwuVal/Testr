using System.Threading.Tasks;
using Testr.Domain.DTOs;

namespace Testr.Infrastructure.AccountServices
{
    public interface IAccountService
    {
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO model);
    }
}
