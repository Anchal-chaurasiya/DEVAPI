using MyApp.Models.Common;
using System;

namespace DevApi.Models
{
    public class UomDto : BaseDto
    {
        public Guid? UomGuid { get; set; }
        public int UomId { get; set; }
     
        public string UomName { get; set; }
    }
    public class UomResponseDTO
    {
        public int UomId { get; set; }

        public string UomName { get; set; }
    }
}