using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Register
{
    public class RegisterHandlerInput : IRequest<RegisterHandlerOutput>
    {
        public NewUser newUser { get; set; }
    }
    public class NewUser
    {
        [Required]

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 8 characters")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        [Required]

        public string Address { get; set; }
    }
}
