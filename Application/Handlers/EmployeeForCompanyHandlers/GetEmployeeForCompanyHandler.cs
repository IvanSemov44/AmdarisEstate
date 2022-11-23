using Application.Queries.EmployeeForCompanyQueries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObject;

namespace Application.Handlers.EmployeeForCompanyHandlers
{
    internal sealed class GetEmployeeForCompanyHandler : IRequestHandler<GetEmployeeForCompanyQuery, EmployeeDto>
    {
        private IMapper _mapper;
        private IRepositoryManager _repositoryManager;

        public GetEmployeeForCompanyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeForCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(request.CompanyId, request.TrackChanges);
            if (company == null)
                throw new CompanyNotFoundException(request.CompanyId);

            var employee = await _repositoryManager.Employee.GetEmployeeAsync(request.CompanyId, request.EmployeeId, request.TrackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(request.EmployeeId);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }
    }
}
