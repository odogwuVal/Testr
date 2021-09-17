using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;

namespace Testr.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICandidateRepository _candidate;

        Response responseBody = new Response();
        public CandidatesController(UserManager<ApplicationUser> userManager, ICandidateRepository candidate)
        {
            _userManager = userManager;
            _candidate = candidate;
        }

        [HttpGet]
        public async Task<ActionResult<List<Candidate>>> GetAllCandidate()
        {
            var candidates = await _candidate.GetAllAsync();
           

            var userCandidates = await _candidate.GetAllAsync();
            if (userCandidates != null)
            {
                responseBody.Message = "Candidate Profile";
                responseBody.Status = "Success";
                responseBody.Payload = null;
                return Ok(responseBody);
            }

            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateAsync([FromRoute] long id)
        {
            var candidate = await _candidate.GetByIdAsync(id);
            if (candidate == null)
            {
                responseBody.Message = "Candidate with corresponding id does not exists";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return NotFound(responseBody);
            }

            return candidate;
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

            await _candidate.AddAsync(model, user);

            responseBody.Message = "Registration was successful.";
            responseBody.Status = "Success";
            responseBody.Payload = null;
            return Created("", responseBody);
        }
    }
}
