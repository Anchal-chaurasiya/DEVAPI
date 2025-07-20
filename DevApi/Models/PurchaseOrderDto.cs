
using MyApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
namespace DevApi.Models
{
    public class PurchaseOrderReqDto:BaseDto
    {
        public Guid PurchaseGuid { get; set; }
        public long PurchaseId { get; set; }
        public long VendorId { get; set; }
        public int PurchaseOrderNo { get; set; }
        public string PlaceOfSupply { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ShippingTermId { get; set; }
        public int PaymentTermId { get; set; }
        public string RefNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContachPersonNo { get; set; }
        public string? ContachPersonEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancel{ get; set; }
        public long AddressId{ get; set; }
        public List<PurchaseOrderDetailReqDto>purchaseOrderDetailReqDtos { get; set; } = new List<PurchaseOrderDetailReqDto>();
        public List<PurchaseOrderPaymentReqDto> purchaseOrderPaymentReqDtos { get; set; } = new List<PurchaseOrderPaymentReqDto>();

    }
    public class PurchaseOrderDetailReqDto 
    {
        public Guid? PurchaseDetailGuid { get; set; }
        public long? PurchaseDetailId { get; set; }
        public long PurchaseId { get; set; }
        public int Sno { get; set; }
        public long ItemId { get; set; }
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
    public class PurchaseOrderPaymentReqDto
    {
        public Guid? PurchasePaymentGuid { get; set; }
        public long? PurchasePaymentId { get; set; }
        public long? PurchaseId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; }
        public string? RefrenceNo { get; set; }
    }
    }
