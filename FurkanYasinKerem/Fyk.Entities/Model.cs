using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyk.Entities
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public int MarkaId { get; set; }
        [ForeignKey("MarkaId")]
        public Marka Marka { get; set; }
    }
}
