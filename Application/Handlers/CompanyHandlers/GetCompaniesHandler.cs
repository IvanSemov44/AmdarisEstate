namespace IvanRealEstate.Application.Handlers.CompanyHandlers
{
    using Application.Queries.CompanyQueries;
    using AutoMapper;
    using Contracts;
    using MediatR;
    using Shared.DataTransferObject;

    internal sealed class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetCompaniesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _repositoryManager.Company.GetAllCompaniesAsync(request.TrackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
        }
    }
}
