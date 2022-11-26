using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get;}
        IEmployeeRepository Employee { get;}

        IEstateRepository Estate { get; }
        ICityRepository City { get;}
        ICountryRepository Country { get;}
        ICurencyRepository Curency { get; }
        IEstateTypeRepository EstateType { get; }
        IImageRepository Image { get; }

        Task SaveAsync();
    }
}
