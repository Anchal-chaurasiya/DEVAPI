using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DevApi.BAL;
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
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService companyService;
        private readonly IConfiguration _configuration;

        public CompanyController(CompanyService companyService, IConfiguration configuration)
        {
            this.companyService = companyService;
            _configuration = configuration;
        }

        [HttpPost("AddCompanyService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> SaveCompany([FromBody] CommonRequestDto<CompanyDto> request)
        {
            var response = companyService.SaveCompany(request);
            return Ok(response);
        }

        [HttpPost("UpdateCompanyService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> UpdateCompany([FromBody] CommonRequestDto<CompanyDto> request)
        {
            var response = companyService.UpdateCompany(request);
            return Ok(response);
        }

        [HttpPost("GetCompanyListService")]
        public ActionResult<CommonResponseDto<List<CompanyDto>>> GetCompanyList([FromBody] CommonRequestDto<int> request)
        {
            var response = companyService.GetCompanyList(request);
            return Ok(response);
        }

        [HttpPost("GetCompanyService")]
        public ActionResult<CommonResponseDto<CompanyDto>> GetCompanyByGuid([FromBody] CommonRequestDto<Guid> request)
        {
            var response = companyService.GetCompanyByGuid(request);
            return Ok(response);
        }

        [HttpGet("GetCompanyDropdownService")]
        public ActionResult<List<CompanyDto>> GetCompanyDropdown(CommonRequestDto<int> request)
        {
            var list = companyService.GetCompanyDropdown(request);
            return Ok(list);
        }
    }
}