namespace IvanRealEstate.Application.Queries.CompanyQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Company;

    public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
}
