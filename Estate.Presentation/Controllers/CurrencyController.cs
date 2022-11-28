namespace IvanRealEstate.Presentation.Controllers
{
    using IvanRealEstate.Application.Commands.CurencyCommands;
    using IvanRealEstate.Shared.DataTransferObject.Currency;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ISender _sender;

        public CurrencyController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyForCreationDto currencyForCreationDto)
        {
            var currencyForReturn = await _sender.Send(new CreateCurrencyCommand(currencyForCreationDto));

            return Ok(currencyForReturn);
        }


    }
}
