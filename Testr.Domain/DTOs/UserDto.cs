using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Domain.DTOs
{
    public class UserDto
    {
        public long UserId { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "EmailAddress is Reqired")]
        public string EmailAddress { get; set; }

        public DateTime LastLoginDate { get; set; }
    }
}
