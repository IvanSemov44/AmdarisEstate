namespace IvanRealEstate.Application.Handlers.EmployeeForCompanyHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Shared.DataTransferObject;
    using IvanRealEstate.Application.Queries.EmployeeForCompanyQueries;

    internal sealed class GetEmployeesForCompanyHandler : IRequestHandler<GetEmployeesForCompanyQuery, IEnumerable<EmployeeDto>>
    {
        private IMapper _mapper;
        private IRepositoryManager _repositoryManager;

        public GetEmployeesForCompanyHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesForCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(request.CompanyId, request.TrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(request.CompanyId);

            var employeesFromDB = await _repositoryManager.Employee.GetEmployeesAsync(request.CompanyId, request.TrackChanges);

            var employeeForReturn = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDB);

            return employeeForReturn;
        }
    }
}
