using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;

namespace Testr.Infrastructure.AccountServices
{
    public interface IAccountService
    {
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordDTO model);
    }
}
