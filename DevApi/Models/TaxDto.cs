using MyApp.Models.Common;

namespace MyApp.Models
{
    public class TaxDto : BaseDto
    {
        public Guid? TaxGuid { get; set; }
        public long TaxId { get; set; }
        public string TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
    }
}