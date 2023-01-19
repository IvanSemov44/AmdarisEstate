namespace IvanRealEstate.Presentation.Controllers
{
    using IvanRealEstate.Application.Commands.UsersCommands;
    using IvanRealEstate.Application.Handlers.UsersHandlers;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Presentation.ActionFilter;
    using IvanRealEstate.Shared.DataTransferObject.Users;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationContoller : ControllerBase
    {
        private readonly ISender _sender;
        private readonly UserManager<User> _userManager;

        public AuthenticationContoller(ISender sender, UserManager<User> userManager)
        {
            _sender = sender;
            _userManager = userManager;
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
            var user = await _userManager.FindByNameAsync(userForAuthentication.UserName);
            var role = await _userManager.GetRolesAsync(user);

            return Ok(new
            {
                Token = await _sender.Send(new CreateTokenCommand(userForAuthentication)),
                id = user.Id,
                username = user.UserName,
                userRole = role
            }) ;
        }

    }
}
