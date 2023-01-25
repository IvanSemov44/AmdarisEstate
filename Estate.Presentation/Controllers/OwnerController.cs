namespace IvanRealEstate.Presentation.Controllers
{
    using IvanRealEstate.Application.Queries.UsersQuery;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/owner")]
    [ApiController]
    public class OwnderController : ControllerBase
    {
        private readonly ISender _sender;

        public OwnderController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet("{userId:guid}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var result = await _sender.Send(new GetUserByIdQuery(userId));

            return Ok(result);
        }
    }
}
