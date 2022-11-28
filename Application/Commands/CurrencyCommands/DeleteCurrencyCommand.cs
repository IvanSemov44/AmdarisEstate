namespace IvanRealEstate.Application.Commands.CurrencyCommands
{
    using MediatR;

    public sealed record DeleteCurrencyCommand(Guid CurrencyId, bool TrackChanges) : IRequest;
}
