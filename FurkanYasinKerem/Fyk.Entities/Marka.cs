using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.Entities
{
    public class Marka : BaseEntity
    {
        public string Name { get; set; }
        public string logoAd { get; set; }
        public IEnumerable<Model>? Modeller { get; set; }
    }
}
