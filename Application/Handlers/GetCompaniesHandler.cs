using Application.Queries;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObject;

namespace Application.Handlers
{
    internal sealed class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetCompaniesHandler(IRepositoryManager repositoryManager,IMapper mapper)
        {
            this._mapper = mapper;
            this._repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _repositoryManager.Company.GetAllCompaniesAsync(request.TrackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
        }
    }
}
