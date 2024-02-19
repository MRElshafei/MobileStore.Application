using Application.Features.Login;
using Application.Features.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Application.Feature.Orders.Command;

namespace MobileStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/User/Login
        [HttpPost("Login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] UserLogin userLoginInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessage = string.Join(", ", ModelState.Where(x => x.Value.Errors.Any())
                                                                    .Select(x => x.Key));
                    return BadRequest($"The following fields are required: {errorMessage}");
                }

                var loginHandlerInput = new LoginHandlerInput
                {
                    userLogin= userLoginInput
                };

                var message = await _mediator.Send(loginHandlerInput);

                if (message == null)
                {
                    return NotFound();
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/User/Register
        [HttpPost("Register")]
        public async Task<ActionResult<string>> RegisterAsync([FromBody] NewUser newUserInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessage = string.Join(", ", ModelState.Where(x => x.Value.Errors.Any())
                                                                    .Select(x => x.Key));
                    return BadRequest($"The following fields are required: {errorMessage}");
                }

                var registerHandlerInput = new RegisterHandlerInput
                {
                    newUser= newUserInput
                };

                var message = await _mediator.Send(registerHandlerInput);

                if (message == null)
                {
                    return NotFound();
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
