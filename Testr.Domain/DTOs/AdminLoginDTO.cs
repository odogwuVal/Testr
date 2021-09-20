using System.ComponentModel.DataAnnotations;

namespace Testr.Domain.DTOs
{
    public class AdminLoginDTO
    {
        [EmailAddress(ErrorMessage = "This is not a valid Email")]
        [Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
