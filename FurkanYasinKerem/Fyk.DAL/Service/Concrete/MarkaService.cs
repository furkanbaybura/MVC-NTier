using AutoMapper;
using Fyk.DAL.Profiles;
using Fyk.DAL.Repositories.Abstract;
using Fyk.DAL.Repositories.Concrete;
using Fyk.DAL.Service.Abstract;
using Fyk.Entities;
using FykDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.DAL.Service.Concrete
{
    public class MarkaService : Service<Marka, MarkaDto>
    {
        public MarkaService(MarkaRepo repo) : base(repo)
        {
            MapperConfiguration config = new MapperConfiguration(config => {
                Profile profile = new MarkaProfile();
                config.AddProfile(profile);
            });
            
            base.Mapper = config.CreateMapper();
        }
    }
}
