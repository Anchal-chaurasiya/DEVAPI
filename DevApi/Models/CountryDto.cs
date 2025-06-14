using MyApp.Models.Common;

namespace DevApi.Models
{
    public class CountryDto: BaseDto
    {
        public Guid? CountryGuid { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
    }
}
