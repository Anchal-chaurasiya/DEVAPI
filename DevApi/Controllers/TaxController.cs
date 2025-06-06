using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaxController : ControllerBase
    {
        private readonly TaxService taxService;
        private readonly IConfiguration _configuration;

        public TaxController(TaxService taxService, IConfiguration configuration)
        {
            this.taxService = taxService;
            _configuration = configuration;
        }

        [HttpPost("AddTaxService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> SaveTax([FromBody] CommonRequestDto<TaxDto> request)
        {
            var response = taxService.SaveTax(request);
            return Ok(response);
        }

        [HttpPost("UpdateTaxService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> UpdateTax([FromBody] CommonRequestDto<TaxDto> request)
        {
            var response = taxService.UpdateTax(request);
            return Ok(response);
        }

        [HttpPost("GetTaxListService")]
        public ActionResult<CommonResponseDto<List<TaxDto>>> GetTaxList([FromBody] CommonRequestDto<int> request)
        {
            var response = taxService.GetTaxList(request);
            return Ok(response);
        }

        [HttpPost("GetTaxService")]
        public ActionResult<CommonResponseDto<TaxDto>> GetTaxByGuid([FromBody] CommonRequestDto<Guid> request)
        {
            var response = taxService.GetTaxByGuid(request);
            return Ok(response);
        }
    }
}