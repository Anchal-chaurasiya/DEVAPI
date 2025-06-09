using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using DevApi.Models.Common;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] /// Require JWT token for all actions in this controller
    public class ItemGroupController : Controller
    {
        private readonly ItemGroupService itemGroupService;
        private readonly IConfiguration _configuration;

        public ItemGroupController(ItemGroupService itemGroupService, IConfiguration configuration)
        {
            this.itemGroupService = itemGroupService;
            _configuration = configuration;
        }

        [HttpPost("AddItemGroupService")]
        public IActionResult AddItemGroup([FromBody] CommonRequestDto<ItemGroupDto> request)
        {
            var result = itemGroupService.SaveItemGroup(request);
            if (result.Flag == 1)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("UpdateItemGroupService")]
        public IActionResult UpdateItemGroup([FromBody] CommonRequestDto<ItemGroupDto> request)
        {
            var result = itemGroupService.UpdateItemGroup(request);
            if (result.Flag == 1)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("GetItemGroupListService")]
        public ActionResult<List<ItemGroupDto>> GetItemGroupList([FromBody] CommonRequestDto<int> request)
        {
            var list = itemGroupService.GetItemGroupList(request);
            return Ok(list);
        }

        [HttpPost("GetItemGroupService")]
        public ActionResult<CommonResponseDto<ItemGroupDto>> GetItemGroupByGuid(CommonRequestDto<Guid> commonRequest)
        {
            var item = itemGroupService.GetItemGroupByGuid(commonRequest);
            if (item != null)
                return Ok(item);
            else
                return NotFound();
        }

        [HttpGet("GetItemGroupDropdownService")]
        public ActionResult<List<ItemGroupDto>> GetItemGroupDropdown()
        {
            var list = itemGroupService.GetItemGroupDropdown();
            return Ok(list);
        }
    }
}