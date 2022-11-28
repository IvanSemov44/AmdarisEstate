namespace Application.Commands.CompanyCommands
{
    using MediatR;

    public sealed  record DeleteCompanyCommand(Guid Id, bool TrackChanges) : IRequest;
}
