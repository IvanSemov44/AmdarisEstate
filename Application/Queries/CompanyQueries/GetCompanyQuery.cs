namespace IvanRealEstate.Application.Queries.CompanyQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Company;

    public sealed record GetCompanyQuery(Guid Id, bool TrackChanges) : IRequest<CompanyDto>;
}
