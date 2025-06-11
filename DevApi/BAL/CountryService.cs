using DevApi.Models;
using DevApi.Models.Common;
using Dapper;
using System;
using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.BAL
{
    public class CountryService
    {
        public CommonResponseDto<List<CountryDto>> GetCountryList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<CountryDto>>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            string proc = "Proc_SaveCountry"; // Use your actual proc name
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3); // Use the correct ProcId for "get list"

            var list = DBHelperDapper.GetAllModelList<CountryDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

    }
}