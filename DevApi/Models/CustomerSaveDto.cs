using DevApi.Models.Enums;
using MyApp.Models.Common;
using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public class CustomerSaveDto : BaseDto
    {
        public Guid? CustomerGuid { get; set; }
        public long? CustomerId { get; set; }
        public string? CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string GSTN { get; set; }
        public int CompanyId { get; set; }
        public int CustomerType { get; set; }
        public int ShippingTermType { get; set; }
        public string? ShippingTermTypeName { get; set; }
        public int PaymentTermType { get; set; }
        public string? PaymentTermTypeName { get; set; }
        public string GSTType{ get; set; }
        public List<CustomerAddressDto> Addresses { get; set; }
    }

    public class CustomerAddressDto : BaseDto
    {
        public Guid? AddressGuid { get; set; }
        public string AddressType { get; set; } // "Billing" or "Shipping"
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string ZipCode { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public string? StateName { get; set; }
        public string? CountryName { get; set; }
        public string? GSTN { get; set; }


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
        public Guid? CustomerGuid { get; set; }
        public int? CustomerType { get; set; } // 1 for Customer, 2 for Vendor
    }

    public class CustomerList
    {
        public int CustomerId { get; set; }
        public Guid CustomerGuid { get; set; }
        public string CustomerName { get; set; }
        public int ShippingTermId{ get; set; }
        public string ShippingTerm{ get; set; }

        public int PaymentTermId { get; set; }
        public string PaymentTerm { get; set; }
    }
    public class CustomerListAddrrss 
    {
        public int AddressId { get; set; }
        public int AddressType { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int StateId{ get; set; }
         public string AddressTypeName
        {
            get
            {
                return Enum.IsDefined(typeof(BillingTypeEnum), AddressType)
                    ? ((BillingTypeEnum)AddressType).ToString()
                    : string.Empty;
            }
        }
    }
}