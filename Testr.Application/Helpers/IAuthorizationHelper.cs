using System.Threading.Tasks;

namespace Testr.Application.Helpers
{
    public interface IAuthorizationHelper
    {

        public long GetCurrentCandidateId();


        public Task<bool> CurrentUserHasRoleAsync(string roleName);
    }
}
