using MyApp.Models;
using DevApi.Models.Common;
using Dapper;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyApp.BAL
{
    public class CustomerService
    {
        public CommonResponseDto<ValidationMessageDto> SaveCustomer(CommonRequestDto<CustomerSaveDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            var customer = request.Data;
            string proc = "Proc_SaveCustomerWithAddresses";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CustomerGuid", customer.CustomerGuid);
            queryParameter.Add("@CustomerCode", customer.CustomerCode);
            queryParameter.Add("@CustomerName", customer.CustomerName);
            queryParameter.Add("@Email", customer.Email);
            queryParameter.Add("@Mobile", customer.Mobile);
            queryParameter.Add("@GSTN", customer.GSTN);
            queryParameter.Add("@createdBy", customer.CreatedBy);
            queryParameter.Add("@Remarks", customer.Remarks);
            queryParameter.Add("@CustomerType", customer.CustomerType);
            queryParameter.Add("@IsActive", customer.IsActive);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            queryParameter.Add("@AddressList",JsonConvert.SerializeObject( customer.Addresses));

            var result = DBHelperDapper.GetAllModelNew<CustomerSaveDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag;
            response.Message = result.Message;
            return response;
        }

        public CommonResponseDto<List<CustomerListDto>> GetCustomerList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<CustomerListDto>>();
            string proc = "Proc_SaveCustomerWithAddresses";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 2); // 2 for list
            queryParameter.Add("@CustomerType", request.Data); // Pass CustomerType as filter
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            var result = DBHelperDapper.GetAllModelList<CustomerListDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public CommonResponseDto<CustomerSaveDto> GetCustomerByGuid(CommonRequestDto<Guid> request)
        {
            var response = new CommonResponseDto<CustomerSaveDto>();
            string proc = "Proc_SaveCustomerWithAddresses";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3); // 3 for get one
            queryParameter.Add("@CustomerGuid", request.Data);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            var result = DBHelperDapper.GetModelFromJson<CustomerSaveDto>(proc, queryParameter);
           response.Data = result;
            response.Flag = result != null ? 1 : 0;
            response.Message = result != null ? "Success" : "Customer not found";
            return response;
        }
    }
} 