﻿using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges);
        Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

        Task<EmployeeDto> CreateEmployeeForCompanyAsync(
             Guid companyId,
             EmployeeForCreationDto employeeForCreationDto,
             bool trackChanges);

        Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);

        Task UpdateEmployeeForCompanyAsync(
            Guid companyId,
            Guid id,
            EmployeeForUpdateDto employee,
            bool compTrackChanges,
            bool empTrackChanges);
    }
}
