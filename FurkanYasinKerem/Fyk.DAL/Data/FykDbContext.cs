using Fyk.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.DAL.Data
{
    public class FykDbContext : DbContext
    {
        public DbSet<Marka> Markalar {  get; set; }
        public DbSet<Model> Modeller { get; set; }
        public FykDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
