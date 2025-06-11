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
    public class StateController : ControllerBase
    {
        private readonly StateService stateService;
        private readonly IConfiguration _configuration;

        public StateController(StateService stateService, IConfiguration configuration)
        {
            this.stateService = stateService;
            _configuration = configuration;
        }

        [HttpPost("GetStateListService")]
        public ActionResult<CommonResponseDto<List<StateDto>>> GetStateList([FromBody] CommonRequestDto<int> request)
        {
            var response = stateService.GetStateList(request);
            return Ok(response);
        }
    }
}