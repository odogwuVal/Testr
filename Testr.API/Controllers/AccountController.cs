using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Infrastructure.AccountServices;
using Testr.Infrastructure.EmailServices;

namespace Testr.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IMailService mailService, IConfiguration configuration)
        {
            _accountService = accountService;
            _mailService = mailService;
            _configuration = configuration;
        }

        
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            Response responseBody = new Response();
            if (string.IsNullOrEmpty(email))
            {
                responseBody.Message = "Email address not specified";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }

             await _accountService.ForgotPasswordAsync(email);

            responseBody.Message = $"A password reset link has been sent to {email}";
            responseBody.Status = "Success";
            responseBody.Payload = null;

            return Ok(responseBody);
        }

      
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromForm] ResetPasswordDTO model)
        {
            Response responseBody = new Response();
            if (!ModelState.IsValid)
            {
                responseBody.Message = "Validation failed. Please check your entries and try again";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }

            await _accountService.ResetPasswordAsync(model);

            responseBody.Message = "Password has been reset successfully";
            responseBody.Status = "Success";
            responseBody.Payload = null ;

            return Ok(responseBody);

        }

    }
}
