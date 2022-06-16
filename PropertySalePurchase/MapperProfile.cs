using AutoMapper;
using PropertySalePurchase.Contract.Dto;
using PropertySalePurchase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertySalePurchase
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserMaster, UserMasterDto>().ReverseMap();
            CreateMap<UserMaster, UserMasterCreateUpdateDto>().ReverseMap();
        }
    }
}
