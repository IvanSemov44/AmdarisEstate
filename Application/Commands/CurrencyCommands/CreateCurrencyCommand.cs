namespace IvanRealEstate.Application.Commands.CurrencyCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    public sealed record CreateCurrencyCommand(CurrencyForCreationDto CurrencyForCreationDto)
        : IRequest<CurrencyDto>;
}
