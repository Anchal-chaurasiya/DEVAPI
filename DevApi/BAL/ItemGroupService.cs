using Azure.Core;
using Dapper;
using DevApi.Models.Common;
using DevApi.Models.Enums;
using MyApp.Models;
using System;
using System.Collections.Generic;

namespace MyApp.BAL
{
    public class ItemGroupService
    {
        public CommonResponseDto<ValidationMessageDto> SaveItemGroup(CommonRequestDto<ItemGroupDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            var itemGroup = request.Data;
            string proc = "Proc_SaveItemGroup";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@ItemGroupName", itemGroup.ItemGroupName);
            queryParameter.Add("@Description", itemGroup.Description);
            queryParameter.Add("@createdBy", itemGroup.CreatedBy);
            queryParameter.Add("@Remarks", itemGroup.Remarks);

            var result = DBHelperDapper.GetAllModelNew<ItemGroupDto, ValidationMessageDto>(proc, queryParameter);

            response.Data = result;
            response.Flag = result.Flag == 1 ? (int)ResponseEnum.Success : (int)ResponseEnum.Error;
            response.Message = result.Message;

            return response;
        }

        public CommonResponseDto<ValidationMessageDto> UpdateItemGroup(CommonRequestDto<ItemGroupDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };

            var itemGroup = request.Data;
            string proc = "Proc_SaveItemGroup";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@ItemGroupId", itemGroup.ItemGroupId);
            queryParameter.Add("@ItemGroupName", itemGroup.ItemGroupName);
            queryParameter.Add("@Description", itemGroup.Description);
            queryParameter.Add("@createdBy", itemGroup.CreatedBy);
            queryParameter.Add("@Remarks", itemGroup.Remarks);

            var result = DBHelperDapper.GetAllModelNew<ItemGroupDto, ValidationMessageDto>(proc, queryParameter);

            response.Data = result;
            response.Flag = result.Flag == 1 ? (int)ResponseEnum.Success : (int)ResponseEnum.Error;
            response.Message = result.Flag == 1 ? "ItemGroup updated successfully." : "Failed to update ItemGroup.";

            return response;
        }

        public CommonResponseDto<List<ItemGroupDto>>  GetItemGroupList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<ItemGroupDto>>
            {
                CompanyId = request.CompanyId,
                PageSize = request.PageSize,
                PageRecordCount = request.PageRecordCount
            };
            string proc = "Proc_SaveItemGroup";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3);

            var list = DBHelperDapper.GetAllModelList<ItemGroupDto>(proc, queryParameter);
            response.Data = list;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public CommonResponseDto<ItemGroupDto> GetItemGroupByGuid(CommonRequestDto<Guid> commonRequest)
        {
            var response = new CommonResponseDto<ItemGroupDto>();

            string proc = "Proc_SaveItemGroup";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@ItemGroupGuid", commonRequest.Data);

            var itemGroup = DBHelperDapper.GetAllModel<ItemGroupDto>(proc, queryParameter);
            response.Data = itemGroup;
            response.Flag = itemGroup != null ? 1 : 0;
            response.Message = itemGroup != null ? "Success" : "Not found";
            return response;
        }

        public List<ItemGroupDto> GetItemGroupDropdown()
        {
            string proc = "Proc_SaveItemGroup";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 5);

            var res = DBHelperDapper.GetAllModel<List<ItemGroupDto>>(proc, queryParameter);
            return res;
        }
    }
}