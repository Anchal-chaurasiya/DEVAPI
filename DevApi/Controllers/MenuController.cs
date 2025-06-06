using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly MenuService menuService;

        public MenuController(MenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpPost("GetUserMenuListService")]
        public ActionResult<List<UserMenuDto>> GetUserMenuList([FromBody] CommonRequestDto<int> commonRequestDto)
        {
            var list = menuService.GetUserMenuList(commonRequestDto);
            return Ok(list);
        }
    }
}