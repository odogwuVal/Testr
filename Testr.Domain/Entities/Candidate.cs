
using System;
using System.ComponentModel.DataAnnotations;
using Testr.Domain.DTOs;

namespace Testr.Domain.Entities
{
    public class Candidate : CandidateBase
    {    
        [Key]
        [Required]
        public long CandidateId { get; set; }

        [Required]
        public long UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public DateTime LastModified { get; set; }

        public bool IsActive { get; set; }
    }
}
