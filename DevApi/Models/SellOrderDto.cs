using MyApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
namespace DevApi.Models
{

    public class SellOrderReqDto : BaseDto
    {
        public Guid SellGuid { get; set; }
        public long SellId { get; set; }
        public long CustomerId { get; set; }
        public int SellOrderNo { get; set; }
        public string PlaceOfSupply { get; set; }
        public DateTime SellOrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ShippingTermId { get; set; }
        public int PaymentTermId { get; set; }
        public string RefNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContachPersonNo { get; set; }
        public string? ContachPersonEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancel { get; set; }
        public long AddressId { get; set; }
        public string SellType { get; set; }
        public List<SellOrderDetailReqDto> SellOrderDetailReqDtos { get; set; } = new List<SellOrderDetailReqDto>();
        public List<SellOrderPaymentReqDto> SellOrderPaymentReqDtos { get; set; } = new List<SellOrderPaymentReqDto>();

    }
    public class SellOrderDetailReqDto
    {
        public Guid? SellDetailGuid { get; set; }
        public long? SellDetailId { get; set; }
        public long SellId { get; set; }
        public int Sno { get; set; }
        public long ItemId { get; set; }
        public string? ItemDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? CGSTRate { get; set; }
        public decimal? CGSTAmount { get; set; }
        public decimal? SGSTRate { get; set; }
        public decimal? SGSTAmount { get; set; }
        public decimal? IGSTRate { get; set; }
        public decimal? IGSTAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class SellOrderPaymentReqDto
    {
        public Guid? SellPaymentGuid { get; set; }
        public long? SellPaymentId { get; set; }
        public long? SellId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; }
        public string? RefrenceNo { get; set; }
    }

    public class SellOrderListDto
    {
        public Guid SellGuid { get; set; }
        public long SellId { get; set; }
        public int SellOrderNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string RefNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancel { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount
        {
            get
            {
                return TotalAmount - PaidAmount;
            }
        }
        public string CreatedDate { get; set; }

    }

    public class SellOrderUpdateDto
    {
        public Guid SellGuid { get; set; }
        public string CancelRemark { get; set; }
    }
    public class MaxSellOrderNoDto
    {
        public int SellOrderNo { get; set; }
    }

    public class UpdateSellOrderPaymentDto
    {
        public Guid SellGuid { get; set; }
        public List<SellOrderPaymentReqDto> SellOrderPaymentReqDtos { get; set; } = new List<SellOrderPaymentReqDto>();
    }

    #region THIS DTO ONLY USE FOR VIEW ON UI SIDE
    public class SellOrderViewDto
    {
        public int SellOrderNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ContactPersonName { get; set; }
        public string ContachPersonEmail { get; set; }
        public string ContachPersonNo { get; set; }
        public string BAddress { get; set; }
        public string SAddress { get; set; }
        public string BStateName { get; set; }
        public string SStateName { get; set; }
        public string RefNo { get; set; }
        public string PlaceOfSupply { get; set; }
        public DateTime SellOrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ShippingTerm { get; set; }
        public int PaymentTerm { get; set; }
        public decimal TotalAmount { get; set; }
        public string SellType { get; set; }
        public List<SellItemViewDto> Items { get; set; }
        public List<SellPaymenViewtDto> Payments { get; set; }

        public class SellItemViewDto
        {
            public int Sno { get; set; }
            public string ItemCode { get; set; }
            public string ItemName { get; set; }
            public decimal Qty { get; set; }
            public decimal Price { get; set; }
            public decimal DiscountPercentage { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal IGSTRate { get; set; }
            public decimal IGSTAmount { get; set; }
            public decimal CGSTRate { get; set; }
            public decimal CGSTAmount { get; set; }
            public decimal SGSTRate { get; set; }
            public decimal SGSTAmount { get; set; }
            public decimal TotalAmount { get; set; }
        }
        public class SellPaymenViewtDto
        {
            public decimal Amount { get; set; }
            public string PaymentMode { get; set; }
            public string RefrenceNo { get; set; }
            public DateTime CreatedOn { get; set; }
        }
    }

    #endregion
}
