using Fyk.DAL.Data;
using Fyk.DAL.Repositories.Abstract;
using Fyk.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.DAL.Repositories.Concrete
{
    public class ModelRepo : Repo<Model>
    {
        public ModelRepo(FykDbContext context) : base(context)
        {
        }

        public override Model? GetById(int id)
        {
            return _context.Modeller.Include(x => x.Marka).Where(x=> x.Id == id).SingleOrDefault();
        }
    }
}
