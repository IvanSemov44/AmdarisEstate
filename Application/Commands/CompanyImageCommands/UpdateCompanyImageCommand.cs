
namespace IvanRealEstate.Application.Commands.CompanyImageCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.CompanyImage;

    public record UpdateCompanyImageCommand
        (Guid CompanyId,
        Guid CompanyImageId,
        CompanyImageForUpdateDto CompanyImageForUpdateDto,
        bool CompanyTrackChanges,
        bool CompanyImageTrackChanges)
        : IRequest;
}
