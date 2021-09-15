using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;

namespace Testr.API.Controllers
{
    public class CandidateController : ControllerBase
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ICandidateRepository _candidate;

        //public CandidateController(UserManager<ApplicationUser> userManager, ICandidateRepository candidate)
        //{
        //    _userManager = userManager;
        //    _candidate = candidate;
        //}

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            Response responseBody = new Response();

            //var userExists = await _userManager.FindByEmailAsync(model.EmailAddress);
            //if (userExists != null)
            //{
            //    responseBody.Message = "A user with email address already exists";
            //    responseBody.Status = "Failed";
            //    responseBody.Payload = null;
            //    return Conflict(responseBody);
            //}
            //Candidate candidateData = new Candidate()
            //{
            //    FirstName = model.FirstName,
            //    AcademicQualification = model.AcademicQualification,
            //    CountryOfOrigin = model.CountryOfOrigin,
            //    DateOfBirth = model.DateOfBirth,
            //    DateRegistered = model.DateRegistered,
            //    EmailAddress = model.EmailAddress,
            //    Gender = model.Gender,
            //    GitHubUrl = model.GitHubUrl,
            //    IsActive = model.IsActive,
            //    LastModified = model.LastModified,
            //    LastName = model.LastName,
            //    LinkedInUrl = model.LinkedInUrl,
            //    MiddleName = model.MiddleName,
            //    NYSCCompleted = model.NYSCCompleted,
            //    PhoneNumber1 = model.PhoneNumber1,
            //    PhoneNumber2 = model.PhoneNumber2,
            //    PhotoUrl = model.PhotoUrl,
            //    ResidentialAddress = model.ResidentialAddress,
            //    ResumeUrl = model.ResumeUrl,
            //    StateOfOrigin = model.StateOfOrigin,
            //};
            //ApplicationUser user = new ApplicationUser()
            //{
            //    Email = model.EmailAddress,
            //    Candidate = candidateData
            //};

            //var result = await _userManager.CreateAsync(user, model.Password);
            //if (!result.Succeeded)
            //{
            //    responseBody.Message = "Registration was not successful. Please try again";
            //    responseBody.Status = "Failed";
            //    responseBody.Payload = null;
            //    return BadRequest(responseBody);
            //}           

            responseBody.Message = "Registration was successful.";
            responseBody.Status = "Success";
            responseBody.Payload = null;
            return Created("", responseBody);
        }
    }
}
