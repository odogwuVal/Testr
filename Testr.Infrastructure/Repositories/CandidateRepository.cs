using System;
using System.Threading.Tasks;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces;
using Testr.Infrastructure.Authentication;

namespace Testr.Infrastructure.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task AddAsync(CandidateRegistration candidateInfo, ApplicationUser userInfo)
        {
            Candidate candidateData = new Candidate()
            {
                FirstName = candidateInfo.FirstName,
                AcademicQualification = candidateInfo.AcademicQualification,
                CountryOfOrigin = candidateInfo.CountryOfOrigin,
                DateOfBirth = candidateInfo.DateOfBirth,
                DateRegistered = DateTime.Now,
                EmailAddress = candidateInfo.EmailAddress,
                Gender = candidateInfo.Gender,
                GitHubUrl = candidateInfo.GitHubUrl,
                IsActive = true,
                LastName = candidateInfo.LastName,
                LinkedInUrl = candidateInfo.LinkedInUrl,
                MiddleName = candidateInfo.MiddleName,
                NYSCCompleted = candidateInfo.NYSCCompleted,
                PhoneNumber1 = candidateInfo.PhoneNumber1,
                PhoneNumber2 = candidateInfo.PhoneNumber2,
                PhotoUrl = candidateInfo.PhotoUrl,
                ResidentialAddress = candidateInfo.ResidentialAddress,
                ResumeUrl = candidateInfo.ResumeUrl,
                StateOfOrigin = candidateInfo.StateOfOrigin,
                User = userInfo
            };

            await _context.Candidates.AddAsync(candidateData);

            await _context.SaveChangesAsync();
        }
    }
}
