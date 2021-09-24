using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Application.Helpers
{
    public interface IAuthorizationHelper
    {

        public long GetCurrentCandidateId();


        public Task<bool> CurrentUserHasRoleAsync(string roleName);
    }
}
