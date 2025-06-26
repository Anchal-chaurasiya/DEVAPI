using DevApi.Models;
using DevApi.Models.Common;
using Dapper;
using System;
using System.Collections.Generic;
using MyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.BAL
{
    public class UomService
    {
        public CommonResponseDto<List<UomDto>> GetUomList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<UomDto>>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            string proc = "Proc_SaveUom";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3); // Convention: 3 = get list
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            var list = DBHelperDapper.GetAllModelList<UomDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public CommonResponseDto<UomDto> GetUomByGuid(CommonRequestDto<Guid> request)
        {
            var response = new CommonResponseDto<UomDto>();

            string proc = "Proc_SaveUom";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 4); // Convention: 4 = get by guid
            queryParameter.Add("@UomGuid", request.Data);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            var uom = DBHelperDapper.GetAllModel<UomDto>(proc, queryParameter);
            response.Data = uom;
            response.Flag = uom != null ? 1 : 0;
            response.Message = uom != null ? "Success" : "Not found";
            return response;
        }

        public CommonResponseDto<List<UomResponseDTO>> GetUomDropdown(CommonRequestDto<int> request)
        {
           
            string proc = "Proc_SaveUom";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 5); // Use a new ProcId for dropdown
            queryParameter.Add("@CompanyId", request.CompanyId);
            queryParameter.Add("@MCompanyGuid", request.MCompanyGuid);
            queryParameter.Add("@CompanyGuid", request.CompanyGuid);
            var result = DBHelperDapper.GetAllModelList<UomResponseDTO>(proc, queryParameter);
            var response = new CommonResponseDto<List<UomResponseDTO>>
            {
                Data= result,
            };
            return response;

        }
    }

   
}