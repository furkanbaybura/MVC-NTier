using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FykDtos
{
    public class MarkaDto : BaseDto
    {
        public string Name { get; set; }
        public string logoAd { get; set; }
        public IEnumerable<ModelDto>? Modeller { get; set; }
    }
}
