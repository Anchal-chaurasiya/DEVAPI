using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using MyApp.Models;
using System;
using System.Collections.Generic;
namespace DevApi.BAL
{
    public class SellOrderService
    {
        public CommonResponseDto<ValidationMessageDto> SaveSellOrder(CommonRequestDto<SellOrderReqDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_SaveSellOrder";
            var queryParameter = new DynamicParameters();

            // Main Sell order fields
            queryParameter.Add("@ProcId", 1);

            queryParameter.Add("@CustomerId", request.Data.CustomerId);
            queryParameter.Add("@SellOrderNo", request.Data.SellOrderNo);
            queryParameter.Add("@PlaceOfSupply", request.Data.PlaceOfSupply);
            queryParameter.Add("@SellOrderDate", request.Data.SellOrderDate);
            queryParameter.Add("@DeliveryDate", request.Data.DeliveryDate);
            queryParameter.Add("@ShippingTermId", request.Data.ShippingTermId);
            queryParameter.Add("@PaymentTermId", request.Data.PaymentTermId);
            queryParameter.Add("@RefNo", request.Data.RefNo);
            queryParameter.Add("@ContactPersonName", request.Data.ContactPersonName);
            queryParameter.Add("@ContachPersonNo", request.Data.ContachPersonNo);
            queryParameter.Add("@ContachPersonEmail", request.Data.ContachPersonEmail);
            queryParameter.Add("@TotalAmount", request.Data.TotalAmount);
            queryParameter.Add("@AddressId", request.Data.AddressId);
            queryParameter.Add("@SAddressId", request.Data.SAddressId);
            queryParameter.Add("@IsActive", request.Data.IsActive);
            queryParameter.Add("@IsCancel", request.Data.IsCancel);
            queryParameter.Add("@CreatedBy", request.UserId);
            queryParameter.Add("@Remarks", request.Data.Remarks);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@McompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@SellType", request.Data.SellType);

            // Serialize details and payments as JSON (if your proc expects JSON)
            queryParameter.Add("@SellOrderDetailsJson",
                Newtonsoft.Json.JsonConvert.SerializeObject(request.Data.SellOrderDetailReqDtos));
            queryParameter.Add("@SellOrderPaymentsJson",
                Newtonsoft.Json.JsonConvert.SerializeObject(request.Data.SellOrderPaymentReqDtos));

            var result = DBHelperDapper.GetAllModelNew<SellOrderReqDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? 1 : 0;
            response.Message = result.Message;
            return response;
        }

        public CommonResponseDto<List<SellOrderListDto>> GetSellOrderList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<SellOrderListDto>>();
            string proc = "Proc_SaveSellOrder";
            var queryParameter = new Dapper.DynamicParameters();
            queryParameter.Add("@ProcId", 3);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@McompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@PageNumber", request.PageSize);
            queryParameter.Add("@PageRecordCount", request.PageRecordCount);

            var list = DBHelperDapper.GetPagedModelList<SellOrderListDto>(proc, queryParameter);
            response = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public CommonResponseDto<ValidationMessageDto> UpdateSellOrder(CommonRequestDto<SellOrderUpdateDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_SaveSellOrder";
            var queryParameter = new Dapper.DynamicParameters();
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@McompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@SellGuid", request.Data.SellGuid);
            queryParameter.Add("@CancelRemark", request.Data.CancelRemark);
            queryParameter.Add("@CreatedBy", request.UserId);

            var list = DBHelperDapper.GetAllModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public CommonResponseDto<MaxSellOrderNoDto> MaxSellORderNo(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<MaxSellOrderNoDto>();
            string proc = "Proc_SaveSellOrder";
            var queryParameter = new Dapper.DynamicParameters();
            queryParameter.Add("@ProcId", 5);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@McompanyGuid", request.MCompanyGuid);
            var list = DBHelperDapper.GetAllModel<MaxSellOrderNoDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public CommonResponseDto<ValidationMessageDto> UpdatePaymentSellOrder(CommonRequestDto<UpdateSellOrderPaymentDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_SaveSellOrder";
            var queryParameter = new DynamicParameters();

            // Main Sell order fields
            queryParameter.Add("@ProcId", 6);

            queryParameter.Add("@SellGuid", request.Data.SellGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@McompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CreatedBy", request.UserId);
            // Serialize details and payments as JSON (if your proc expects JSON)

            queryParameter.Add("@SellOrderPaymentsJson",
                Newtonsoft.Json.JsonConvert.SerializeObject(request.Data.SellOrderPaymentReqDtos));

            var result = DBHelperDapper.GetAllModelNew<UpdateSellOrderPaymentDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? 1 : 0;
            response.Message = result.Message;
            return response;
        }
        public CommonResponseDto<SellOrderViewDto> SellOrderView(CommonRequestDto<Guid> request)
        {
            var response = new CommonResponseDto<SellOrderViewDto>();
            string proc = "Proc_SaveSellOrder";
            var queryParameter = new Dapper.DynamicParameters();
            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@SellGuid", request.Data);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@McompanyGuid", request.MCompanyGuid);
            var list = DBHelperDapper.GetModelFromJson<SellOrderViewDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
