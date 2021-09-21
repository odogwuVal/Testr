using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces.Base;

namespace Testr.Domain.Interfaces
{
    public interface IAdminRepository : IRepository<Administrator>
    {
        public Task AddAsync(AdminRegistrationDTO registrationInfo, ApplicationUser userInfo);
    }
}
