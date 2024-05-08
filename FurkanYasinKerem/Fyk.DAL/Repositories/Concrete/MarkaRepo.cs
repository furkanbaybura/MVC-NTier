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
    public class MarkaRepo : Repo<Marka>
    {
        public MarkaRepo(FykDbContext context) : base(context)
        {
        }
        public override IEnumerable<Marka> GetAll()
        {
            return _context.Markalar.Include(x=> x.Modeller).ToList();
        }
    }
}
