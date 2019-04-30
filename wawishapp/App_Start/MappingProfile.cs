using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wawishapp.Dtos;
using wawishapp.Models;

namespace wawishapp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}