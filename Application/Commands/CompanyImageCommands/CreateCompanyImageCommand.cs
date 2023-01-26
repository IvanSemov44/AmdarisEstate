

using IvanRealEstate.Shared.DataTransferObject.CompanyImage;
using IvanRealEstate.Shared.DataTransferObject.Image;
using MediatR;

namespace IvanRealEstate.Application.Commands.CompanyImageCommands
{
    public record CreateCompanyImageCommand
        (Guid CompanyId, CompanyImageForCreationDto CompanyImageForCreationDto, bool TrackChanges)
        : IRequest<CompanyImageDto>;
}
