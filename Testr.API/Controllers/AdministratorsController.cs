using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testr.API.Controllers
{   [Authorize (Roles ="SuperAdmin, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAdminRepository _adminRepository;

        public AdministratorsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
                IConfiguration configuration, IAdminRepository adminRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _adminRepository = adminRepository;
        }

            [Authorize (Roles ="SuperAdmin")]
            [HttpPost]
            [Route("register-admin")]
            public async Task<IActionResult> RegisterAdmin([FromBody] AdminRegistrationDTO model)
            {
                Response responseBody = new Response();

            ApplicationUser adminExist = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (adminExist != null)
            {
                responseBody.Message = "An Administrator with this Email Address already exist";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return Conflict(responseBody);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.EmailAddress,
                UserName = model.EmailAddress,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                responseBody.Message = "Administrator registration was not successful. Please try again.";
                responseBody.Status = "Failed";
                responseBody.Payload = null;
                return BadRequest(responseBody);
            }

            await _adminRepository.AddAsync(model, user);

            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new ApplicationRole() { Name = "Admin" });


            if (await _roleManager.RoleExistsAsync("Admin"))
                await _userManager.AddToRoleAsync(user, "Admin");

            responseBody.Message = "Admin registration completed successfully.";
            responseBody.Status = "Success";
            responseBody.Payload = $" An Admin with email {user.UserName} has been provisioned";
            return Created($"/users/{user.Id}", responseBody);
        }
    }
}
