﻿using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompany(bool trackChanges);
    }
}
