
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
        public async Task AddAsync(CycleDTO cycleInfo, Administrator admin)
        {
            _context.Cycles.Add(
                       new Cycle

                       {
                           CycleName = cycleInfo.CycleName,
                           Status = cycleInfo.Status,
                           DateOpened = cycleInfo.DateOpened,
                           DateClosed = cycleInfo.DateClosed,
                           Description = cycleInfo.Description,
                           CreatedBy = admin,
                           DateCreated = DateTime.Now
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