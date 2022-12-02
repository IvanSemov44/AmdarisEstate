namespace IvanRealEstate.Application.Handlers.CompanyHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.DataTransferObject;
    using IvanRealEstate.Application.Commands.CompanyCommands;


    internal sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
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
