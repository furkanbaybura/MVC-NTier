using Fyk.DAL.Service.Abstract;
using Fyk.Entities;
using FykDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.BLL.Managers.Abstract
{
    public abstract class Manager<TDto, TEntity> : IManager<TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        protected Service<TEntity, TDto> _service;
        public Manager(Service<TEntity, TDto> service)
        {
            _service = service;
        }

        public int Add(TDto dto){return _service.Add(dto);}
        public int Delete(TDto dto){ return _service.Delete(dto);}
        public TDto? GetById(int id){return _service.GetById(id);}
        public IEnumerable<TDto> GetAll(){return _service.GetAll();}
        public int Update(TDto dto){return _service.Update(dto);}
    }
}
