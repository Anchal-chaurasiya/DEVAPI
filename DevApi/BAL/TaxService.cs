using MyApp.Models;
using DevApi.Models.Common;
using DevApi.Models.Enums;
using Dapper;
using System;
using System.Collections.Generic;

namespace MyApp.BAL
{
    public class TaxService
    {
        public CommonResponseDto<ValidationMessageDto> SaveTax(CommonRequestDto<TaxDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            var tax = request.Data;
            string proc = "Proc_SaveTax";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@TaxName", tax.TaxName);
            queryParameter.Add("@TaxPercentage", tax.TaxPercentage);
            queryParameter.Add("@createdBy", tax.CreatedBy);
            queryParameter.Add("@Remarks", tax.Remarks);

            var result = DBHelperDapper.GetAllModelNew<TaxDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag == 1 ? (int)ResponseEnum.Success : (int)ResponseEnum.Error;
            response.Message = result.Message;

            return response;
        }

        public CommonResponseDto<TaxDto> UpdateTax(CommonRequestDto<TaxDto> request)
        {
            var response = new CommonResponseDto<TaxDto>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            var tax = request.Data;
            string proc = "Proc_SaveTax";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@TaxGuid", tax.TaxGuid);
            queryParameter.Add("@TaxName", tax.TaxName);
            queryParameter.Add("@TaxPercentage", tax.TaxPercentage);
            queryParameter.Add("@createdBy", tax.CreatedBy);
            queryParameter.Add("@Remarks", tax.Remarks);
            queryParameter.Add("@IsActive", tax.IsActive);

            var dbResult = DBHelperDapper.GetAllModelNew<TaxDto, CommonResponseDto<TaxDto>>(proc, queryParameter);
            response.Data = dbResult.Data;
            response.Flag = dbResult.Flag;
            response.Message = dbResult.Message;
            return response;
        }

        public CommonResponseDto<List<TaxDto>> GetTaxList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<TaxDto>>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            string proc = "Proc_SaveTax";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3);

            var list = DBHelperDapper.GetAllModelList<TaxDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public CommonResponseDto<TaxDto> GetTaxByGuid(CommonRequestDto<Guid> request)
        {
            var response = new CommonResponseDto<TaxDto>();

            string proc = "Proc_SaveTax";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@TaxGuid",request.Data);

            var tax = DBHelperDapper.GetAllModel<TaxDto>(proc, queryParameter);
            response.Data = tax;
            response.Flag = tax != null ? 1 : 0;
            response.Message = tax != null ? "Success" : "Not found";
            return response;
        }

        public List<TaxDto> GetTaxDropdown()
        {
            string proc = "Proc_SaveTax";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 5);

            var res = DBHelperDapper.GetAllModelList<TaxDto>(proc, queryParameter);
            return res;
        }
    }
}