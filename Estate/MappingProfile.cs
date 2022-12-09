namespace IvanRealEstate
{
    using AutoMapper;

    using IvanRealEstate.Entities.Models;

    using IvanRealEstate.Shared.DataTransferObject;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Shared.DataTransferObject.Currency;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;
    using IvanRealEstate.Shared.DataTransferObject.Image;

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

            //----Estate Mapper------
            CreateMap<EstateForCreationDto, Entities.Models.Estate>();

            CreateMap<Entities.Models.Estate, EstateDto>();

            CreateMap<EstateForUpdateDto, Entities.Models.Estate>();


            //----City Mapper------
            CreateMap<CityForCreationDto, City>();

            CreateMap<City, CityDto>();

            CreateMap<CityForUpdateDto, City>();

            //----Country Mapper------
            CreateMap<Country, CountryDto>();

            CreateMap<CountryForCreationDto, Country>();

            CreateMap<CountryForUpdateDto, Country>();

            //----Curency Mapper-------
            CreateMap<Currency, CurrencyDto>();

            CreateMap<CurrencyForCreationDto, Currency>();

            CreateMap<CurrencyForUpdateDto, Currency>();

            //----EstateType Mapper------
            CreateMap<EstateType, EstateTypeDto>();

            CreateMap<EstateTypeForCreationDto, EstateType>();

            CreateMap<EstateTypeForUpdateDto, EstateType>();

            //----City Mapper------
            CreateMap<Image, ImageDto>();

            CreateMap<ImageForCreationDto, Image>();

            CreateMap<ImageForUpdateDto, Image>();
        }
    }
}
