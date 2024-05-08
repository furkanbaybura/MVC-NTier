using AutoMapper;
using Fyk.Entities;
using FykDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.DAL.Profiles
{
    public class MarkaProfile : Profile
    {
        public MarkaProfile()
        {
            CreateMap<Marka, MarkaDto>().ForMember(dest => dest.Modeller, opt => opt.MapFrom(src => src.Modeller));
            CreateMap<MarkaDto, Marka>().ForMember(dest => dest.Modeller, opt => opt.MapFrom(src => src.Modeller));
            CreateMap<MarkaDto, Marka>().ReverseMap();
            CreateMap<ModelDto, Model>().ReverseMap();
        }
    }
}
