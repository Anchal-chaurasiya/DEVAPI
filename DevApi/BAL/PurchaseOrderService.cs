using DevApi.Models;
using DevApi.Models.Common;
using Dapper;
using System;
using System.Collections.Generic;
using MyApp.Models;

namespace DevApi.BAL
{
    public class PurchaseOrderService
    {
        public CommonResponseDto<ValidationMessageDto> SavePurchaseOrder(CommonRequestDto<PurchaseOrderReqDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_SavePurchaseOrder";
            var queryParameter = new DynamicParameters();

            // Main purchase order fields
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@PurchaseGuid", request.Data.PurchaseGuid);
            queryParameter.Add("@PurchaseId", request.Data.PurchaseId);
            queryParameter.Add("@VendorId", request.Data.VendorId);
            queryParameter.Add("@PurchaseOrderNo", request.Data.PurchaseOrderNo);
            queryParameter.Add("@PlaceOfSupply", request.Data.PlaceOfSupply);
            queryParameter.Add("@PurchaseOrderDate", request.Data.PurchaseOrderDate);
            queryParameter.Add("@DeliveryDate", request.Data.DeliveryDate);
            queryParameter.Add("@ShippingTermId", request.Data.ShippingTermId);
            queryParameter.Add("@PaymentTermId", request.Data.PaymentTermId);
            queryParameter.Add("@RefNo", request.Data.RefNo);
            queryParameter.Add("@ContactPersonName", request.Data.ContactPersonName);
            queryParameter.Add("@ContachPersonNo", request.Data.ContachPersonNo);
            queryParameter.Add("@ContachPersonEmail", request.Data.ContachPersonEmail);
            queryParameter.Add("@TotalAmount", request.Data.TotalAmount);
            queryParameter.Add("@IsActive", request.Data.IsActive);
            queryParameter.Add("@IsCancel", request.Data.IsCancel);
            queryParameter.Add("@CreatedBy", request.Data.CreatedBy);
            queryParameter.Add("@Remarks", request.Data.Remarks);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@McompanyGuid", request.MCompanyGuid);

            // Serialize details and payments as JSON (if your proc expects JSON)
            queryParameter.Add("@PurchaseOrderDetailsJson", 
                Newtonsoft.Json.JsonConvert.SerializeObject(request.Data.purchaseOrderDetailReqDtos));
            queryParameter.Add("@PurchaseOrderPaymentsJson", 
                Newtonsoft.Json.JsonConvert.SerializeObject(request.Data.purchaseOrderPaymentReqDtos));

            var result = DBHelperDapper.GetAllModelNew<PurchaseOrderReqDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? 1 : 0;
            response.Message = result.Message;
            return response;
        }
    }
}