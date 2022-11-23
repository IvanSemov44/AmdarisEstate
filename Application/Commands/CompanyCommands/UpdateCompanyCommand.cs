using MediatR;
using Shared.DataTransferObject;

namespace Application.Commands.CompanyCommands
{
    public sealed record UpdateCompanyCommand(Guid Id, CompanyForUpdateDto CompanyForUpdate, bool TrackChanges) : IRequest;
}
