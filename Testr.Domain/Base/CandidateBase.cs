using System;
using System.ComponentModel.DataAnnotations;

namespace Testr.Domain.DTOs
{
    public class CandidateBase
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        [Required(ErrorMessage = "EmailAddress is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(20)]
        [Phone]
        [Required(ErrorMessage = "Phone Number is required")]
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
        public string AcademicQualification { get; set; }

        [Required]
        public bool NYSCCompleted { get; set; }

        public string LinkedInUrl { get; set; }

        public string ResumeUrl { get; set; }

        public string GitHubUrl { get; set; }
    }
}
