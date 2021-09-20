using System.ComponentModel.DataAnnotations;
using Testr.Domain.Base;

namespace Testr.Domain.DTOs
{
    public class AdminRegistration : AdministratorBase
    {
        [Required(ErrorMessage = "Password is required."), MinLength(8), MaxLength(20)]
        public string Password { get; set; }
    }
}
