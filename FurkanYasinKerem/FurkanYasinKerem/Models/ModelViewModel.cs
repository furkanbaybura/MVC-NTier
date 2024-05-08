using System.ComponentModel.DataAnnotations.Schema;

namespace FurkanYasinKerem.Models
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarkaId { get; set; }
        [ForeignKey("MarkaId")]
        public MarkaViewModel Marka { get; set; }
        public int RowNum { get; set; }
    }
}
