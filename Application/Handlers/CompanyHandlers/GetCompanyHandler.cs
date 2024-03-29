﻿namespace IvanRealEstate.Application.Handlers.CompanyHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions.NotFound;
    using IvanRealEstate.Application.Queries.CompanyQueries;
    using IvanRealEstate.Shared.DataTransferObject.Company;

    internal sealed class GetCompanyHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

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
