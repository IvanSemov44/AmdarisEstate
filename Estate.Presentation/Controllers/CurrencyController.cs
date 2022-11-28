namespace IvanRealEstate.Presentation.Controllers
{
    using IvanRealEstate.Application.Commands.CurencyCommands;
    using IvanRealEstate.Application.Queries.CurrencyQueries;
    using IvanRealEstate.Entities.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetCurrencies()
        {
            var currenciesForReturn = await _sender.Send(new GetCurrenciesQuery(TrackChanges: false));

            return Ok(currenciesForReturn);
        }

        [HttpGet("{currencyId:guid}",Name ="GetCurrencyById")]
        public async Task<IActionResult> GetCurrencyById(Guid currencyId)
        {
            var currency = await _sender.Send(new GetCurrencyQuery(currencyId, TrackChanges: false));

            return Ok(currency);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyForCreationDto currencyForCreationDto)
        {
            var currencyForReturn = await _sender.Send(new CreateCurrencyCommand(currencyForCreationDto));

            return CreatedAtRoute("GetCurrencyById",new { currencyId = currencyForReturn.CurrencyId},currencyForReturn);
        }


    }
}
