﻿using AutoMapper;
using Entities.DTO.Register;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.CustomerModels;
using Entities.Models.EmployeeModels;
using Entities.Models.InvoiceModels;
using Entities.Models.SuperMarketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<SuperMarketRequestDto, SuperMarket>().ReverseMap();
            CreateMap<SuperMarket, SuperMarketResponseDto>().ReverseMap();
            CreateMap<SuperMarketRequestDto, SuperMarketRegisterDto>().ReverseMap();

            // Maps for Employee
            CreateMap<EmployeeRequestDto, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeResponseDto>().ReverseMap();
            CreateMap<EmployeeRequestDto, EmployeeRegisterDto>().ReverseMap();

            // Mapping for the Customer
            CreateMap<CustomerRequestDto, Customer>().ReverseMap();
            CreateMap<Customer, CustomerResponseDto>().ReverseMap();

            // Mapping for InvoiceDetails
            CreateMap<InvoiceDetailsRequestDto, InvoiceDetails>().ReverseMap();
            CreateMap<InvoiceDetails, InvoiceDetailsResponseDto>().ReverseMap();

            // Mapping for Invoice
        }
    }
}
