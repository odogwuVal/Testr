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
using Testr.Domain.Interfaces;
using Testr.Infrastructure.EmailModel;
using Testr.Infrastructure.EmailServices;

namespace Testr.API.Controllers
{
    [Route("api/email")]
    [ApiController]
    //[Authorize (Roles = "SuperAdmin, Admin")]
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
        [Route("Single-email-send")]
        public async Task SendEmail([FromBody] MailRequest mailRequest)
        {
            await _mailService.SendEmailAsync(mailRequest);
            await Task.FromResult(0);
        }

        [HttpPost]
        [Route("Bulk-email-send")]
        public async Task SendBulkEmail([FromBody] MailRequest mailRequest)
        {
            var candidates = await _candidateRepo.GetAllAsync();
            foreach (var candidate in candidates)
            {
                mailRequest.ToEmail = candidate.EmailAddress;
                await _mailService.SendEmailAsync(mailRequest);
                await Task.FromResult(0);
            }            
        }

        //private string CreateEmailBody(string userName, string message)
        //{
        //    string body = string.Empty;
        //    // using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/htmlTemplate.html")))
        //    using (StreamReader reader = new StreamReader(Path.Combine(_host.ContentRootPath, 
        //        "/Testr.Infrastructure/EmailTemplates/RegistrationAcknowledgment.txt")))
        //    {
        //        body = reader.ReadToEnd();
        //    }
        //    body = body.Replace("{FirstName}", userName);
        //    // body = body.Replace("{message}", message);
        //    return body;
        //}

    }
}
