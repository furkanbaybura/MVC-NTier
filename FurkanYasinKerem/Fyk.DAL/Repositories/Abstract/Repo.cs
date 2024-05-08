using Fyk.DAL.Data;
using Fyk.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.DAL.Repositories.Abstract
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity
    {
        protected FykDbContext _context;
        protected DbSet<TEntity> entities;


        public Repo(FykDbContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();

        }
        public int Add(TEntity entity)
        {
            entities.Add(entity);
            return _context.SaveChanges();

        }

        public int Delete(TEntity entity)
        {
            entities.Remove(entity);
            return _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public  virtual TEntity? GetById(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public int Update(TEntity entity)
        {
            TEntity entity1 = GetById(entity.Id);
            entity.Created = entity1.Created;
            entity.Updated = DateTime.Now;

            entities.Update(entity);

            return _context.SaveChanges();
        }
    }
}
