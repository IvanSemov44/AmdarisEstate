namespace IvanRealEstate.Application.Handlers.EmployeeForCompanyHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Shared.DataTransferObject;
    using IvanRealEstate.Application.Commands.EmployeeForCompanyCommands;

    internal sealed class CreateEmployeeForCompanyHandler : IRequestHandler<CreateEmployeeForCompanyCommand, EmployeeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateEmployeeForCompanyHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeForCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(request.CompanyId, request.TrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(request.CompanyId);

            var employee = _mapper.Map<Employee>(request.Employee);

            _repositoryManager.Employee.CreateEmployeeForCompany(request.CompanyId, employee);
            await _repositoryManager.SaveAsync();

            var employeeForReturn = _mapper.Map<EmployeeDto>(employee);

            return employeeForReturn;
        }
    }
}
