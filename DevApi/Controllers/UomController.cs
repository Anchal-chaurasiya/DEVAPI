using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UomController : ControllerBase
    {
        private readonly UomService uomService;
        private readonly IConfiguration _configuration;

        public UomController(UomService uomService, IConfiguration configuration)
        {
            this.uomService = uomService;
            _configuration = configuration;
        }

        [HttpPost("GetUomListService")]
        public ActionResult<CommonResponseDto<List<UomDto>>> GetUomList([FromBody] CommonRequestDto<int> request)
        {
            var response = uomService.GetUomList(request);
            return Ok(response);
        }

        [HttpPost("GetUomService")]
        public ActionResult<CommonResponseDto<UomDto>> GetUomByGuid([FromBody] CommonRequestDto<Guid> request)
        {
            var response = uomService.GetUomByGuid(request);
            return Ok(response);
        }
        [HttpPost("BindUomDropdown")]
        public ActionResult<CommonResponseDto<List<UomResponseDTO>>> BindUomDropdown([FromBody] CommonRequestDto<int> request)
        {
            var result = uomService.GetUomDropdown(request);
            return Ok(result);
        }
    }
}