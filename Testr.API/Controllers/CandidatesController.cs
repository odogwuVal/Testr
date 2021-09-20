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
        private readonly ICandidateRepository _candidateRepo;

        Response responseBody = new Response();
        public CandidatesController(UserManager<ApplicationUser> userManager, ICandidateRepository candidate)
        {
            _userManager = userManager;
            _candidateRepo = candidate;
        }

        [HttpGet]
        public async Task<ActionResult<List<Candidate>>> GetAllCandidate()
        {
            var candidates = await _candidateRepo.GetAllAsync();
            if (candidates != null)
            {
                responseBody.Message = "Sucessfully fetched all candidates";
                responseBody.Status = "Success";
                responseBody.Payload = candidates;
                return Ok(responseBody);
            }
            // Set response body when fetched

            responseBody.Message = "Successfully return responsebody";
            return Ok(responseBody);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateAsync([FromRoute] long id)
        {
            var candidate = await _candidateRepo.GetByIdAsync(id);
            if (candidate == null)
            {
                responseBody.Message = "Candidate with corresponding id does not exists";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return NotFound(responseBody);
            }

            // Set response body when found
            responseBody.Message = "Sucessfully return responsebody";
           
            return Ok(responseBody);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CandidateRegistrationDTO model)
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

            await _candidateRepo.AddAsync(model, user);

            responseBody.Message = "Registration was successful.";
            responseBody.Status = "Success";
            responseBody.Payload = null;
            return Created("", responseBody);
        }
    }
}
