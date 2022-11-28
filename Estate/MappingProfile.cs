namespace Estate
{
    using AutoMapper;
    using Entities.Models;
    using Shared.DataTransferObject;
    using Shared.DataTransferObject.City;
    using Shared.DataTransferObject.Country;
    using Shared.DataTransferObject.Estate;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c=>c.FullAddress,
                opt => opt.MapFrom(x => string.Join(" ", x.Address, x.Country)));

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<Employee,EmployeeDto>();

            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<CompanyForUpdateDto, Company>();

            CreateMap<EstateForCreationDto, Entities.Models.Estate >();

            //--------City Mapper------
            CreateMap<CityForCreationDto, City>();

            CreateMap<City, CityDto>();

            CreateMap<CityForUpdateDto, City>();

            //--------Country Mapper------
            CreateMap<Country, CountryDto>();

            CreateMap<CountryForCreationDto, Country>();

            CreateMap<CountryForUpdateDto, Country>();
        }
    }
}
