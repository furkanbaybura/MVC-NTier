namespace FurkanYasinKerem.Models
{
    public class MarkaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? logoResim { get; set; }
        public string logoAd {  get; set; }
        public IEnumerable<ModelViewModel>? Modeller { get; set; }
        public int RowNum { get; set; }
    }
}
