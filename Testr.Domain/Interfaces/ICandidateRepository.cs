using System.Threading.Tasks;
using Testr.Domain.Entities;
using Testr.Domain.Interfaces.Base;

namespace Testr.Domain.Interfaces
{
    public interface ICandidateRepository : IRepository<Candidate>
    {

        public Task AddAsync(CandidateRegistration candidateInfo, ApplicationUser userInfo);

    }
}
