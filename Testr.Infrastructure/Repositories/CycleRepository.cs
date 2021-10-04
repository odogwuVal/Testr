
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;
using Testr.Infrastructure.Authentication;

namespace Testr.Infrastructure.Repositories
{
    public class CycleRepository : Repository<Cycle>, ICycleRepository
    {
        private readonly AppDbContext _context;

        public CycleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddAsync(CycleRegistrationDTO registrationInfo, ApplicationUser userInfo)
        {
            _context.cycles.Add(
                       new Cycle

                       {
                           CycleName = registrationInfo.CycleName,
                           Status = registrationInfo.Status,
                           DateOpened = registrationInfo.DateOpened,
                           DateClosed = registrationInfo.DateClosed,
                           Description = registrationInfo.Description,
                           LastModified = DateTime.Now
                       }
                       );
            await _context.SaveChangesAsync();
        }

        Task<object> ICycleRepository.DeleteAsync()
        {
            throw new NotImplementedException();
        }

        Task ICycleRepository.UpdateAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}