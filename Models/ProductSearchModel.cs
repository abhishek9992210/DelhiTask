using DelhiTask.Entities;

namespace DelhiTask.Models
{
    public class ProductSearchModel
    {
        //public int? Id { get; set; }
        public string? ProductName { get; set; }
        public char? Size { get; set; }
        public decimal? Price { get; set; }
        public DateTime? MfgDate { get; set; }
        public string? Category { get; set; }

        public string Conjunction { get; set; }
    }

}
