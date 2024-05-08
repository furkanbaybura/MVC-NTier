using Fyk.BLL.Managers.Abstract;
using Fyk.DAL.Service.Abstract;
using Fyk.DAL.Service.Concrete;
using Fyk.Entities;
using FykDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.BLL.Managers.Concrete
{
    public class ModelManager : Manager<ModelDto, Model>
    {
        public ModelManager(ModelService service) : base(service)
        {
            
        }
    }
}
