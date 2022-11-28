﻿namespace IvanRealEstate.Presentation.Controllers
{
    using IvanRealEstate.Application.Commands.CurencyCommands;
    using IvanRealEstate.Application.Commands.CurrencyCommands;
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

        [HttpGet("{currencyId:guid}", Name = "GetCurrencyById")]
        public async Task<IActionResult> GetCurrencyById(Guid currencyId)
        {
            var currency = await _sender.Send(new GetCurrencyQuery(currencyId, TrackChanges: false));

            return Ok(currency);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyForCreationDto currencyForCreationDto)
        {
            var currencyForReturn = await _sender.Send(new CreateCurrencyCommand(currencyForCreationDto));

            return CreatedAtRoute("GetCurrencyById", new { currencyId = currencyForReturn.CurrencyId }, currencyForReturn);
        }

        [HttpPut("{currencyId:guid}")]
        public async Task<IActionResult> UpdateCurrency(Guid currencyId, [FromBody] CurrencyForUpdateDto currencyForUpdateDto)
        {
            await _sender.Send(new UpdateCurrencyCommand(currencyId, currencyForUpdateDto, TrackChanges: true));
            
            return Ok();
        }

        [HttpDelete("{currencyId:guid}")]
        public async Task<IActionResult> DeleteCurrency(Guid currencyId)
        {
            await _sender.Send(new DeleteCurrencyCommand(currencyId, TrackChanges: false));

            return Ok();
        }


    }
}
