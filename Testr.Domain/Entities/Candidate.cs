using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testr.Domain.Base;

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
