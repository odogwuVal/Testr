using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces.Base;

namespace Testr.Domain.Interfaces
{
    public interface ICycleRepository :IRepository<Cycle>
    {
        public Task AddAsync(CycleRegistrationDTO cycleInfo, ApplicationUser userInfo);
       
        Task<object> DeleteAsync();
       
        Task UpdateAsync(long id);
    }
}
