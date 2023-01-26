

namespace IvanRealEstate.Application.Queries.CompanyImageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Shared.DataTransferObject.CompanyImage;

    public record GetCompanyImageQuery(Guid CompanyId, Guid CompanyImageId, bool TrackChanges) : IRequest<CompanyImageDto>;
  
}
