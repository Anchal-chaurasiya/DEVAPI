using DevApi.Models;
using DevApi.Models.Common;
using Dapper;
using System;
using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.BAL
{
    public class StateService
    {
        public CommonResponseDto<List<StateDto>> GetStateList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<StateDto>>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            string proc = "Proc_SaveState"; // Use your actual proc name
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3); // Convention: 3 = get list
            queryParameter.Add("@CountryId", request.Data); // Convention: 3 = get list

            var list = DBHelperDapper.GetAllModelList<StateDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        
    }
}