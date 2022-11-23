using MediatR;

namespace Application.Commands.CompanyCommands
{
    public record DeleteCompanyCommand(Guid Id, bool TrackChanges) : IRequest;
}
