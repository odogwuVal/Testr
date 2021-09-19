using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
       // private readonly ICandidateRepository _candidateRepository;


        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration, ICandidateRepository candidateRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
           // _candidateRepository = candidateRepository;

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] CandidateLogin model)
        {
            Response responseBody = new Response();

            ApplicationUser user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                IList<string> assignedRoles = await _userManager.GetRolesAsync(user);

                List<Claim> authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (string role in assignedRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                // Assign response body properties for successful login
                responseBody.Message = "Logged in successfully";
                responseBody.Status = "Success";
                responseBody.Payload = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
                return Ok(responseBody);
            }

            // Assign response body properties for unsuccessful login
            responseBody.Message = "Login attempt was unsuccessful. Invalid email address or password.";
            responseBody.Status = "Failed";
            responseBody.Payload = null;
            return Unauthorized(responseBody);
        }
    }
}
;