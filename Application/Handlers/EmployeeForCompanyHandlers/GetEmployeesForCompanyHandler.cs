using Application.Queries.EmployeeForCompanyQueries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObject;


namespace Application.Handlers.EmployeeForCompanyHandlers
{
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
