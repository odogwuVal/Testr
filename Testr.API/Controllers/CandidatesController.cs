using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;

namespace Testr.API.Controllers
{
    public class CandidatesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICandidateRepository _candidate;

        public CandidatesController(UserManager<ApplicationUser> userManager, ICandidateRepository candidate)
        {
            _userManager = userManager;
            _candidate = candidate;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CandidateRegistration model)
        {
            Response responseBody = new Response();

            var userExists = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (userExists != null)
            {
                responseBody.Message = "A user with email address already exists";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return Conflict(responseBody);
            }

            Candidate candidateData = new Candidate()
            {
                FirstName = model.FirstName,
                AcademicQualification = model.AcademicQualification,
                CountryOfOrigin = model.CountryOfOrigin,
                DateOfBirth = model.DateOfBirth,
                DateRegistered = DateTime.Now,
                EmailAddress = model.EmailAddress,
                Gender = model.Gender,
                GitHubUrl = model.GitHubUrl,
                IsActive = true,
                LastName = model.LastName,
                LinkedInUrl = model.LinkedInUrl,
                MiddleName = model.MiddleName,
                NYSCCompleted = model.NYSCCompleted,
                PhoneNumber1 = model.PhoneNumber1,
                PhoneNumber2 = model.PhoneNumber2,
                PhotoUrl = model.PhotoUrl,
                ResidentialAddress = model.ResidentialAddress,
                ResumeUrl = model.ResumeUrl,
                StateOfOrigin = model.StateOfOrigin,
            };

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.EmailAddress,
                UserName = model.EmailAddress
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                responseBody.Message = "Registration was not successful. Please try again";
                responseBody.Status = "Failed";
                responseBody.Payload = result;
                return BadRequest(responseBody);
            }

            var userIdData = _userManager.FindByEmailAsync(model.EmailAddress);
            candidateData.UserId = userIdData.Result.Id;
            var result2 = await _candidate.AddAsync(candidateData);
            if (result2 == null)
            {
                responseBody.Message = "Registration was not successful. Please try again";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return BadRequest(responseBody);
            }

            responseBody.Message = "Registration was successful.";
            responseBody.Status = "Success";
            responseBody.Payload = null;
            return Created("", responseBody);
        }
    }
}
