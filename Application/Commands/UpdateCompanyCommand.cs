using MediatR;
using Shared.DataTransferObject;

namespace Application.Commands
{
    public sealed record UpdateCompanyCommand(Guid Id, CompanyForUpdateDto CompanyForUpdate, bool TrackChanges):IRequest;
}
