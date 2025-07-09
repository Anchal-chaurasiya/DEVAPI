using Azure.Core;
using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using MyApp.Models;
using System;
using System.Collections.Generic;

namespace DevApi.BAL
{
    public class SPTermService
    {
        public CommonResponseDto<ValidationMessageDto> AddSPTerm(CommonRequestDto<SPTermDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_SavePaymentTerm";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@SPTermType", request.Data.SPTermType);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            // Add other fields as needed

            var result = DBHelperDapper.GetAllModelNew<SPTermDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? 1 : 0;
            response.Message = result.Message;
            return response;
        }

        public CommonResponseDto<ValidationMessageDto> UpdateSPTerm(CommonRequestDto<SPTermDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            var term = request.Data;
            string proc = "Proc_SavePaymentTerm";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@SPTermGuid", term.SPTermGuid);
            queryParameter.Add("@SPTermType", term.SPTermType);
            queryParameter.Add("@SPTermTypeName", term.SPTermTypeName);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            // Add other fields as needed

            var result = DBHelperDapper.GetAllModelNew<SPTermDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? 1 : 0;
            response.Message = result.Message;
            return response;
        }

        public CommonResponseDto<List<SPTermDto>> GetSPTermList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<SPTermDto>>();
            string proc = "Proc_SavePaymentTerm";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3);
            queryParameter.Add("@SPTermType", request.Data);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);

            var list = DBHelperDapper.GetAllModelList<SPTermDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public CommonResponseDto<SPTermDto> GetSPTermByGuid(CommonRequestDto<Guid> request)
        {
            var response = new CommonResponseDto<SPTermDto>();
            string proc = "Proc_SavePaymentTerm";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@SPTermGuid", request.Data);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);

            var term = DBHelperDapper.GetAllModel<SPTermDto>(proc, queryParameter);
            response.Data = term;
            response.Flag = term != null ? 1 : 0;
            response.Message = term != null ? "Success" : "Not found";
            return response;
        }

        public List<SPTermDto> GetSPTermDropdown(CommonRequestDto<int> request)
        {
            string proc = "Proc_SavePaymentTerm";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 5);
            queryParameter.Add("@SPTermType", request.Data);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);

            var res = DBHelperDapper.GetAllModelList<SPTermDto>(proc, queryParameter);
            return res;
        }
    }
}