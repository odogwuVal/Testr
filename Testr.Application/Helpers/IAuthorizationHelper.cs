using System.Threading.Tasks;
using Testr.Domain.Entities;

namespace Testr.Application.Helpers
{
    public interface IAuthorizationHelper
    {

        public long GetCurrentCandidateId();


        public long GetCurrentAdminId();


        public Administrator GetCurrentAdmin();


        public Task<bool> CurrentUserHasRoleAsync(string roleName);
    }
}
