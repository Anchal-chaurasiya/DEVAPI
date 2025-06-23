namespace DevApi.Models.Common
{
    public class CommonRequestDto<T>
    {
        public int? CompanyId { get; set; }
        public int PageSize { get; set; }
        public int PageRecordCount { get; set; }
        public T Data { get; set; } // Accepts any DTO type

        public long UserId { get; set; }
        public Guid MCompanyGuid { get; set; }
        public Guid CompanyGuid { get; set; }
    }
}