﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObject;
using System.Collections.Generic;

namespace Estate
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Company, CompanyDto>()
                .ForMember(c=>c.FullAddress,
                opt => opt.MapFrom(x => string.Join(" ", x.Address, x.Country)));

            CreateMap<Employee,EmployeeDto>();

        }
    }
}