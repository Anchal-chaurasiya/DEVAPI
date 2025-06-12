using MyApp.Models.Common;

namespace DevApi.Models
{
    public class StateDto:BaseDto
    {
        public Guid? StateGuid { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public int CountryId { get; set; } // Foreign key to Country

    }
}
