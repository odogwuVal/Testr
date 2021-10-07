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
            try
            {
            Response responseBody = new Response();
            var result = await _cycleRepo.GetByIdAsync(id);
            if (result == null)
            {
                responseBody.Message = "Cycle with corresponding id not found";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return NotFound(responseBody);
            }

                responseBody.Message = "Sucessfully fetched cycle Id";
                responseBody.Status = "Success";
                responseBody.Payload = result;
                return Ok(responseBody);

            }

            catch (Exception)
            {
                Response responseBody = new Response();
                responseBody.Message = "Internal Server Error";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return StatusCode(500, responseBody);
        }
        }
       
        [HttpPost]
        public async Task<ActionResult<Cycle>> CreateCycleAsync([FromBody] CycleDTO cycle)
        {
            Response responseBody = new Response();

            try
            {
                Administrator currentAdmin = _authHelper.GetCurrentAdmin();

                await _cycleRepo.AddAsync(cycle, currentAdmin);
                responseBody.Message = "Cycle Creation was successful.";
                responseBody.Status = "Success";
                responseBody.Payload = null;
                return Created("", responseBody);
            }
            catch (Exception)
            {
                responseBody.Message = "Cycle creation was not successful. Please try again";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return BadRequest(responseBody);
            }

        }

    }

}




