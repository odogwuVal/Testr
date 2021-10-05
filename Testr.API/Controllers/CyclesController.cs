using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testr.Application.Helpers;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;

namespace Testr.API.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CyclesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICycleRepository _cycleRepo;
        private readonly IAuthorizationHelper _authHelper;

        public CyclesController(ICycleRepository cycle, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IAuthorizationHelper authHelper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _cycleRepo = cycle;
            _authHelper = authHelper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cycle>>> GetAllCyclesAsync()
        {
            Response responseBody = new Response();
            var result = await _cycleRepo.GetAllAsync();
            // Response body when fetched
            if (result != null)
            {
                responseBody.Message = "Sucessfully fetched all cycles";
                responseBody.Status = "Success";
                responseBody.Payload = result;
                return Ok(responseBody);
            }

            // Set response body when not fetched
            responseBody.Message = "Cycles fetch failed";
            responseBody.Status = "Failed";
            responseBody.Payload = null;
            return NotFound(responseBody);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cycle>> GetCycleAsync([FromRoute] long id)
        {
            Response responseBody = new Response();
            var result = await _cycleRepo.GetByIdAsync(id);
            if (result == null)
            {
                responseBody.Message = "Cycles with corresponding id failed";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return NotFound(responseBody);
            }

            else
            {
                responseBody.Message = "Sucessfully fetched cycle Id";
                responseBody.Status = "Success";
                responseBody.Payload = result;
                return Ok(responseBody);
            }
        }
       

        [HttpPost]
        [Route("Create-cycle")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Cycle cycle)
        {
            Response responseBody = new Response();
            var result = await _cycleRepo.AddAsync(cycle);
            if (result == null)
            {
                responseBody.Message = "Cycle creation was not successful. Please try again";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return BadRequest(responseBody);
            }
            else

            {
                responseBody.Message = "Cycle Creation was successful.";
                responseBody.Status = "Success";
                responseBody.Payload = null;
                return Created("", responseBody);
            }

        }


    }

}



