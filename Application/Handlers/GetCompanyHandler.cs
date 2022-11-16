using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObject;

namespace Application.Handlers
{
    internal sealed class GetCompanyHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        public readonly IRepositoryManager _repositoryManager;
        public readonly IMapper _mapper;

        public GetCompanyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(request.Id, request.TrackChanges);

            if (company is null)
                throw new CompanyNotFoundException(request.Id);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }
    }
}
