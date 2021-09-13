using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Domain.Entities
{
    public class Users
    {
        [MaxLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "EmailAddress is Reqired")]
        public string EmailAddress { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Password is Reqired")]
        public string Password { get; set; }

        public DateTime LastLoginDate { get; set; }


    }

}
