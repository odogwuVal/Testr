using System;
using System.Threading.Tasks;
using Testr.Domain.DTOs;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;
using Testr.Infrastructure.Authentication;

namespace Testr.Infrastructure.Repositories
{
    public class AdminRepository : Repository<Administrator>, IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task AddAsync(AdminRegistration registrationInfo, ApplicationUser userInfo)
        {
            _context.Administrators.Add(
                           new Administrator
                           {


                               FirstName = registrationInfo.FirstName,
                               LastName = registrationInfo.LastName,
                               EmailAddress = registrationInfo.EmailAddress,
                               DateAdded = DateTime.Now,
                               User = userInfo

                           }
                           );


            await _context.SaveChangesAsync();
        }
    }
}
