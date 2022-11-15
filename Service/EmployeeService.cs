using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employee = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(id);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeesFromDb = await _repositoryManager.Employee.GetEmployeesAsync(companyId, trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

            return employeesDto;
        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(
            Guid companyId,
            EmployeeForCreationDto employeeForCreation,
            bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);
            _repositoryManager.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repositoryManager.SaveAsync();

            var employeeForReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeForReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employee = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(id);

            _repositoryManager.Employee.DeleteEmployee(employee);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employee,
            bool campTrackChanges, bool empTrackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, campTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(id);

            _mapper.Map(employee, employeeEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
