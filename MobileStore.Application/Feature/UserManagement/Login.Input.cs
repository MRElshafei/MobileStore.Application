using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Login
{
    public class LoginHandlerInput :  IRequest<LoginHandlerOutput>
    {
        public UserLogin userLogin { get; set; }

    }
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
