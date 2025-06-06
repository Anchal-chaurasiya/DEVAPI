using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using DevApi.Models.Common;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService itemService;

        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpPost("AddItemService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> SaveItem([FromBody] CommonRequestDto<ItemSaveDto> request)
        {
            var result = itemService.SaveItem(request);
            return Ok(result);
        }

        [HttpPost("GetItemListService")]
        public ActionResult<CommonResponseDto<List<ItemListDto>>> GetItemList([FromBody] CommonRequestDto<int> request)
        {
            var result = itemService.GetItemList(request);
            return Ok(result);
        }

        [HttpPost("GetItemService")]
        public ActionResult<CommonResponseDto<ItemSaveDto>> GetItemByGuid([FromBody] CommonRequestDto<ItemReqDto> request)
        {
            var result = itemService.GetItemByGuid(request);
            return Ok(result);
        }
    }
}
