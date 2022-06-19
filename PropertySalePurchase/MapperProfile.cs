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
            CreateMap<UserMaster, UserMasterDto>()
                .ForMember(dest => dest.RoleName, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UserMaster, UserMasterCreateUpdateDto>()
                .ReverseMap();

            CreateMap<RoleMaster, RoleMasterDto>()
                .ReverseMap();

            CreateMap<Enquiry, EnquiryDto>()
                .ReverseMap();

            CreateMap<PropertyDetail, PropertyDetailDto>()
                .ForMember(dest => dest.CityName, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyOwnerName, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyBuyerName, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyType, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyStatus, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PropertyType, PropertyTypeDto>()
                .ReverseMap();

            CreateMap<PropertyStatus, PropertyStatusDto>()
                .ReverseMap();
        }
    }
}
