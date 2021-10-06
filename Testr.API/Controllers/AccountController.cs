using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IAccountService _acccountService;
        private IMailService _mailService;
        private IConfiguration _configuration;

        public AccountController(IAccountService accountService, IMailService mailService, IConfiguration configuration)
        {
            _acccountService = accountService;
            _mailService = mailService;
            _configuration = configuration;
        }


        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            Response responseBody = new Response();
            if (string.IsNullOrEmpty(email))
            {
                responseBody.Message = $"Email address not specified";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }

            bool result = await _acccountService.ForgotPasswordAsync(email);

            responseBody.Message = $"A password reset link has been sent to {email}";
            responseBody.Status = "Success";
            responseBody.Payload = null;

            return Ok(responseBody);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordDTO model)
        {
            Response responseBody = new Response();
            if (!ModelState.IsValid)
            {
                responseBody.Message = $"Email address not found";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }

            bool result = await _acccountService.ResetPasswordAsync(model);

            responseBody.Message = $"Password has been reset successfully";
            responseBody.Status = "Success";
            responseBody.Payload = null;

            return Ok(responseBody);

        }

    }
}
