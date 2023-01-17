namespace IvanRealEstate.Presentation.Controllers
{
    using IvanRealEstate.Application.Commands.UsersCommands;
    using IvanRealEstate.Application.Handlers.UsersHandlers;
    using IvanRealEstate.Presentation.ActionFilter;
    using IvanRealEstate.Shared.DataTransferObject.Users;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationContoller : ControllerBase
    {
        private readonly ISender _sender;

        public AuthenticationContoller(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _sender.Send(new RegisterUsersCommand(userForRegistration));

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            if (!await _sender.Send(new ValidateUserCommand(userForAuthentication)))
                return Unauthorized();

            return Ok(new { Token = await _sender.Send(new CreateTokenCommand(userForAuthentication)) });
        }

    }
}
