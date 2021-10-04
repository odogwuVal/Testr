using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Interfaces;
using Testr.Infrastructure.EmailModel;
using Testr.Infrastructure.EmailServices;

namespace Testr.API.Controllers
{
    [Route("api/email")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class EmailController : ControllerBase
    {
        private readonly IWebHostEnvironment _host;
        private readonly IMailService _mailService;
        private readonly ICandidateRepository _candidateRepo;


        public EmailController(IWebHostEnvironment host, IMailService mailService, ICandidateRepository candidateRepo)
        {
            _host = host;
            _mailService = mailService;
            _candidateRepo = candidateRepo;
        }


        [HttpPost]
        [Route("single-email-send")]
        public async Task<IActionResult> SendEmailAsync([FromBody] MailRequest mailRequest)
        {
            Response responseBody = new Response();

            try
            {
            await _mailService.SendEmailAsync(mailRequest);

                responseBody.Message = "Email sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
        }
            catch (Exception)
            {
                responseBody.Message = "Email not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }
        }

        [HttpPost]
        [Route("bulk-email-send")]
        public async Task<IActionResult> SendBulkEmailAsync([FromBody] MailRequest mailRequest)
        {            
            Response responseBody = new Response();

            try
            {
                var candidates = await _candidateRepo.GetAllAsync();
                foreach (var candidate in candidates)
                {
                    mailRequest.ToEmail = candidate.EmailAddress;
                    await _mailService.SendEmailAsync(mailRequest);
                    await Task.FromResult(0);
                }

                responseBody.Message = "Bulk Email sent successfully";
                responseBody.Status = "Success";
                responseBody.Payload = null;

                return Ok(responseBody);
            }
            catch (Exception)
            {
                responseBody.Message = "Bulk Email not sent";
                responseBody.Status = "Failed";
                responseBody.Payload = null;

                return BadRequest(responseBody);
            }
        }   
    }
}
