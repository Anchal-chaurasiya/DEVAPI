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
    }
}