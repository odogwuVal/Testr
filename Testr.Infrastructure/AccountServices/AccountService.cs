using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Infrastructure.EmailModel;
using Testr.Infrastructure.EmailServices;

namespace Testr.Infrastructure.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public AccountService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMailService mailService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mailService = mailService;

        }


        public async Task<bool> ForgotPasswordAsync(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
        

            // No user matches the email
            if (user == null)
            {
                return false;
            }

            // Matching user found
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";

            //sends the mail to the user
            MailRequest mailRequest = new MailRequest()
            {
                ToEmail = email,
                Subject = "Testr Password Reset",
                Body = $"Click on this link to reset your password: {url}"
            };

            await _mailService.SendEmailAsync(mailRequest);

            return true;
        }


        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user == null)
            {
                return false;
            }
            //***token should be extracted for the URL ***

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            return true;
        }
    }
}
