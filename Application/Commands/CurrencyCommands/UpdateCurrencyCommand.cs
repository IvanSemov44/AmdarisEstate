namespace IvanRealEstate.Application.Commands.CurrencyCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    public sealed record UpdateCurrencyCommand
        (Guid CurrencyId,CurrencyForUpdateDto CurrencyForUpdateDto,bool TrackChanges): IRequest<Unit>
    {
    }
}
