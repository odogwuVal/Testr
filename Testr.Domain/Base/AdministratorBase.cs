using System.ComponentModel.DataAnnotations;

namespace Testr.Domain.Base
{
    public class AdministratorBase
    {
        [Required(ErrorMessage = "First Name is required."), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required."), MaxLength(50)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email Address is required."), MaxLength(150)]
        [EmailAddress(ErrorMessage = "This is not a valid email address.")]
        public string EmailAddress { get; set; }

    }
}
