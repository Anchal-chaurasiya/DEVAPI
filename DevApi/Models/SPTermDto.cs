using DevApi.Models.Enums;
using MyApp.Models.Common;
using System;
using System.Collections.Generic;
namespace DevApi.Models
{
    public class SPTermDto
    {
        public Guid SPTermGuid { get; set; }
        public long SPTermId { get; set; }
       public int SPTerm { get; set; }
        public int SPTermType { get; set; }
        public string SPTermTypeName {
            get
            {
                return Enum.IsDefined(typeof(SPTermEnum), SPTermType)
                    ? ((SPTermEnum)SPTermType).ToString()
                    : string.Empty;
            }
        }

    }
    public class SPTermReqDto
    {
        public int SPTermType { get; set; }
    }
}
