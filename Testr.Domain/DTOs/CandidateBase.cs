using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Domain.DTOs
{
    public class CandidateBase
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "FirstName is Reqired")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "LastName is Reqired")]
        public string LastName { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        [Required(ErrorMessage = "EmailAddress is Reqired")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Date of Birth is Reqired")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(20)]
        [Phone]
        [Required(ErrorMessage = "Phone Number is Reqired")]
        public string PhoneNumber1 { get; set; }

        [MaxLength(20)]
        [Phone]
        public string PhoneNumber2 { get; set; }

        [MaxLength(150)]
        [Required]
        public string ResidentialAddress { get; set; }

        [MaxLength(50)]
        [Required]
        public string StateOfOrigin { get; set; }

        [MaxLength(20)]
        [Required]
        public string Gender { get; set; }

        [MaxLength(50)]
        [Required]
        public string CountryOfOrigin { get; set; }

        public string PhotoUrl { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public DateTime LastModified { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string AcademicQualification { get; set; }

        [Required]
        public bool NYSCCompleted { get; set; }

        public string LinkedInUrl { get; set; }

        public string ResumeUrl { get; set; }

        public string GitHubUrl { get; set; }

    }
}
