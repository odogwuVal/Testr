using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Testr.Domain.Entities;
using Testr.Infrastructure.Authentication;

namespace Testr.Application.Helpers
{
    public class AuthorizationHelper : IAuthorizationHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;


        public AuthorizationHelper(IHttpContextAccessor context, AppDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _httpContext = context;
            _dbContext = dbContext;
            _userManager = userManager;
        }


        private string FetchCurrentUserEmail()
        {
            string userEmail = string.Empty;

            // Extract the user's email from the request object
            Claim userEmailClaim = _httpContext.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault();

            if (userEmailClaim != null)
                userEmail = userEmailClaim.Value;

            return userEmail;
        }


        public async Task<bool> CurrentUserHasRoleAsync(string roleName)
        {
            bool result = false;

            string userEmail = FetchCurrentUserEmail();
            ApplicationUser user = await _userManager.FindByEmailAsync(userEmail);

            if (user != null)
                result = await _userManager.IsInRoleAsync(user, roleName);

            return result;
        }


        public long GetCurrentCandidateId()
        {
            long result = 0;
            string userEmail = FetchCurrentUserEmail();

            // Look up the candidate's id using their email
            Candidate candidate = _dbContext.Candidates
                .Where(c => c.EmailAddress == userEmail)
                .FirstOrDefault();

            if (candidate != null)
                result = candidate.CandidateId;

            return result;
        }
    }
}
