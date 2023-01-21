namespace IvanRealEstate.Presentation.Controllers
{
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
    }
}
