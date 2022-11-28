namespace IvanRealEstate.Application.Commands.CurencyCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    public sealed record CreateCurrencyCommand(CurrencyForCreationDto CurrencyForCreationDto)
        : IRequest<CurrencyDto>;
}
