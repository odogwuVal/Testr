using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Domain.DTOs
{
    class CandidateDto
    {
        public long CandidateId { get; set; }

        public string FirstName { get; set; }
                
        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }
                        
        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public string ResidentialAddress { get; set; }

        public string StateOfOrigin { get; set; }

        public string Gender { get; set; }

        public string CountryOfOrigin { get; set; }

        public string PhotoUrl { get; set; }
        
        public DateTime DateRegistered { get; set; }

        public DateTime LastModified { get; set; }

        public bool IsActive { get; set; }

        public string AcademicQualification { get; set; }

        public bool NYSCCompleted { get; set; }

        public string LinkedInUrl { get; set; }

        public string ResumeUrl { get; set; }

        public string GitHubUrl { get; set; }
    }
}
