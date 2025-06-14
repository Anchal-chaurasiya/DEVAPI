using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApp.BAL;
using MyApp.Models;
using System;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly CountryService countryService;
        private readonly IConfiguration _configuration;

        public CountryController(CountryService countryService, IConfiguration configuration)
        {
            this.countryService = countryService;
            _configuration = configuration;
        }

        [HttpPost("GetCountryListService")]
        public ActionResult<CommonResponseDto<List<CountryDto>>> GetCountryList([FromBody] CommonRequestDto<int> request)
        {
            var response = countryService.GetCountryList(request);
            return Ok(response);
        }

        [HttpGet("GetCountryDropdownService")]
        public ActionResult<List<ItemGroupDto>> GetCountryDropdown()
        {
            var list = countryService.GetCountryDropdown();
            return Ok(list);
        }
    }
}