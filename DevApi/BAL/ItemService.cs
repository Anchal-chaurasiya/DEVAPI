using MyApp.Models;
using DevApi.Models.Common;
using Dapper;
using System.Collections.Generic;

namespace MyApp.BAL
{
    public class ItemService
    {
        public CommonResponseDto<ValidationMessageDto> SaveItem(CommonRequestDto<ItemSaveDto> request)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            var item = request.Data;
            string proc = "Proc_SaveUMItem";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@ItemGuid", item.ItemGuid);
            queryParameter.Add("@ItemCode", item.ItemCode);
            queryParameter.Add("@ItemName", item.ItemName);
            queryParameter.Add("@Description", item.Description);
            queryParameter.Add("@TaxId", item.TaxId);
            queryParameter.Add("@ItemGroupId", item.ItemGroupId);
            queryParameter.Add("@HSNCode", item.HSNCode);
            queryParameter.Add("@CreatedBy", item.CreatedBy);
            queryParameter.Add("@Remarks", item.Remarks);
            queryParameter.Add("@IsActive", item.IsActive);
            queryParameter.Add("@UomId", item.UomId);

            var result = DBHelperDapper.GetAllModelNew<ItemSaveDto, ValidationMessageDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result.Flag;
            response.Message = result.Message;
            return response;
        }

        public CommonResponseDto<List<ItemListDto>> GetItemList(CommonRequestDto<int> request)
        {
            var response = new CommonResponseDto<List<ItemListDto>>();
            string proc = "Proc_SaveUMItem";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3);

            var result = DBHelperDapper.GetAllModelList<ItemListDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public CommonResponseDto<ItemSaveDto> GetItemByGuid(CommonRequestDto<Guid> request)
        {
            var response = new CommonResponseDto<ItemSaveDto>();
            string proc = "Proc_SaveUMItem";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@ItemGuid", request.Data);

            var result = DBHelperDapper.GetAllModel<ItemSaveDto>(proc, queryParameter);
            response.Data = result;
            response.Flag = result != null ? 1 : 0;
            response.Message = result != null ? "Success" : "Item not found";
            return response;
        }
    }
}