namespace IvanRealEstate.Application.Queries.CompanyQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject;

    public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
}
