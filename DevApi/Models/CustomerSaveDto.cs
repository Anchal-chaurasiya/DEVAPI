using DevApi.Models.Enums;
using MyApp.Models.Common;
using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public class CustomerSaveDto : BaseDto
    {
        public Guid CustomerGuid { get; set; }
        public long CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string GSTN { get; set; }
        public int CompanyId { get; set; }
        public int CustomerType { get; set; }
        public List<CustomerAddressDto> Addresses { get; set; }
    }

    public class CustomerAddressDto : BaseDto
    {
        public Guid AddressGuid { get; set; }
        public string AddressType { get; set; } // "Billing" or "Shipping"
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int CompanyId { get; set; }

    }
    public class CustomerListDto : BaseDto
    {
        public Guid? CustomerGuid { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string GSTN { get; set; }
        public int CustomerType { get; set; }
       
        public string CustomerTypeName
        {
            get
            {
                return Enum.IsDefined(typeof(CustomerTypeEnum), CustomerType)
                    ? ((CustomerTypeEnum)CustomerType).ToString()
                    : string.Empty;
            }
        }
    }

    public class CustomerReqDto
    {
        public int CompanyId { get; set; }
        public Guid CustomerGuid { get; set; }
    }
}