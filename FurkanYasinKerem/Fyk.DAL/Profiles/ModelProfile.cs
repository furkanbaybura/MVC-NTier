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
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<ModelDto, Model>().ForMember(dest => dest.Marka, opt => opt.MapFrom(src => src.Marka));
            CreateMap<Model, ModelDto>().ForMember(dest => dest.Marka, opt => opt.MapFrom(src => src.Marka));

            CreateMap<MarkaDto, Marka>().ReverseMap();
        }
    }
}
