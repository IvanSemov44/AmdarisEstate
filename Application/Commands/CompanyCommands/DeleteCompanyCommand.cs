using MediatR;

namespace Application.Commands.CompanyCommands
{
    public sealed  record DeleteCompanyCommand(Guid Id, bool TrackChanges) : IRequest;
}
