using MyApp.Models.Common;
using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public class ItemSaveDto : BaseDto
    {
        public Guid? ItemGuid { get; set; }
        public long ItemId { get; set; }
        public string? ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public long? TaxId { get; set; }
        public long ItemGroupId { get; set; }
        public string HSNCode { get; set; }
        public string? ItemGroupName { get; set; }
        public string? TaxName { get; set; }
        public int? UomId { get; set; }
        public string? UomName { get; set; }
    }

    public class ItemListDto : BaseDto
    {
        public Guid ItemGuid { get; set; }
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public long? TaxId { get; set; }
        public long ItemGroupId { get; set; }
        public string HSNCode { get; set; }
    }

    public class ItemReqDto
    {
        public Guid ItemGuid { get; set; }
    }
}