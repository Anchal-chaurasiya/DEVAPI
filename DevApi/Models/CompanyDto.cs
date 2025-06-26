using MyApp.Models.Common;

namespace DevApi.Models
{
    public class CompanyDto:BaseDto
    {
        public Guid CompanyGuid { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? CompanyType { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string? Logo { get; set; }
        public string? GSTN { get; set; }
        public string? TIN { get; set; }
        public string PAN { get; set; }
        public string BAddress { get; set; }
        public string? BAddress2 { get; set; }
        public string BCity { get; set; }
        public long BStateId { get; set; }
        public long BCountryId { get; set; }
        public string BZipCode { get; set; }
        public string SAddress1 { get; set; }
        public string? SAddress2 { get; set; }
        public string SCity { get; set; }
        public long SStateId { get; set; }
        public long SCountryId { get; set; }
        public string BZipCode1 { get; set; }
        public string? BankName { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountNo { get; set; }
        public string? IFSCCode { get; set; }
        public string? AccountType { get; set; }
        public string? SwiftCode { get; set; }
        public string? UPIId { get; set; }
       
    }
}
