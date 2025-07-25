
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

    public class PurchaseOrderListDto {
        public Guid PurchaseGuid { get; set; }
        public long PurchaseId { get; set; }
        public int PurchaseOrderNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string RefNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancel { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; } 
        public decimal DueAmount { get
            {
             return   TotalAmount-PaidAmount;
            }
        }
        public string CreatedDate { get; set; }

    }

    public class PurchaseOrderUpdateDto
    {
        public Guid PurchaseGuid { get; set; }
        public string CancelRemark { get; set; }
    }
    public class MaxPurchaseOrderNoDto
    {
        public int PurchaseOrderNo { get; set; }    
    }

    public class UpdatePurchaseOrderPaymentDto {
        public Guid PurchaseGuid { get; set; }
        public List<PurchaseOrderPaymentReqDto>purchaseOrderPaymentReqDtos { get; set; } = new List<PurchaseOrderPaymentReqDto>();
    }

    #region THIS DTO ONLY USE FOR VIEW ON UI SIDE
    public class PurchaseOrderViewDto
    {
        public int PurchaseOrderNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ContactPersonName { get; set; }
        public string ContachPersonEmail { get; set; }
        public string ContachPersonNo { get; set; }
        public string Address { get; set; }
        public string RefNo { get; set; }
        public string PlaceOfSupply { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ShippingTerm { get; set; }
        public int PaymentTerm { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PurchaseItemViewDto> Items { get; set; }
        public List<PurchasePaymenViewtDto> Payments { get; set; }

        public class PurchaseItemViewDto
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
        }
        public class PurchasePaymenViewtDto
        {
            public decimal Amount { get; set; }
            public string PaymentMode { get; set; }
            public string RefrenceNo { get; set; }
            public DateTime CreatedOn { get; set; }
        }
    }

    #endregion

}
