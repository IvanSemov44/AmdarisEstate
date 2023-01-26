namespace IvanRealEstate.Application.Queries.CompanyImageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.CompanyImage;

    public record GetAllCompanyImagesQuery(Guid CompanyId, bool TrackChanges) : IRequest<IEnumerable<CompanyImageDto>>;
}
