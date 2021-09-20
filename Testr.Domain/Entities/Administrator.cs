using System;
using System.ComponentModel.DataAnnotations;
using Testr.Domain.Base;

namespace Testr.Domain.Entities
{
    public class Administrator : AdministratorBase
    {
        public long Id { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public long UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}
