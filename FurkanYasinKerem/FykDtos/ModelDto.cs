using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FykDtos
{
    public class ModelDto : BaseDto
    {
        public string Name { get; set; }
        public int MarkaId { get; set; }
        public MarkaDto Marka { get; set; }
    }
}
