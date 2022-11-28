namespace Application.Queries.CompanyQueries
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
}
