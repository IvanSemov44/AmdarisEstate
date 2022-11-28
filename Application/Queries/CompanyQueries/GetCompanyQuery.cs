namespace IvanRealEstate.Application.Queries.CompanyQueries
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record GetCompanyQuery(Guid Id, bool TrackChanges) : IRequest<CompanyDto>;
}
