using MediatR;

namespace IvanRealEstate.Application.Commands.CompanyImageCommands
{
    public record DeleteCompanyImageCommand(Guid CompanyId, Guid CompanyImageId, bool TrackChanges) : IRequest;
}
