using MyApp.Models.Common;

namespace MyApp.Models
{
    public class ItemGroupDto : BaseDto
    {
        public Guid? ItemGroupGuid { get; set; }
        public int ItemGroupId { get; set; }
        public string ItemGroupName { get; set; }
        public string Description { get; set; } // Added property
    }
}