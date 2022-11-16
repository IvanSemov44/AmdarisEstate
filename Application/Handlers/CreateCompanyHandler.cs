using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._mapper = mapper;
            this._repositoryManager = repositoryManager;
        }

        public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = _mapper.Map<Company>(request.CompanyForCreation);

            _repositoryManager.Company.CreateCompany(companyEntity);
            await _repositoryManager.SaveAsync();

            var companyForReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyForReturn;
        }
    }
}
