using Microsoft.AspNetCore.Mvc;
using DevApi.Models;
using DevApi.Models.Enums;
using System;
using System.Collections.Generic;
using Dapper;
using DevApi.Models.Common;
using DevApi.BAL;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SPTermController : ControllerBase
    {
        private readonly SPTermService _spTermService;

        public SPTermController(SPTermService spTermService)
        {
            _spTermService = spTermService;
        }

        [HttpPost("AddSPTermService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> AddSPTerm([FromBody] CommonRequestDto<SPTermDto> request)
        {
            var response = _spTermService.AddSPTerm(request);
            return Ok(response);
        }

        [HttpPost("UpdateSPTermService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> EditSPTerm([FromBody] CommonRequestDto<SPTermDto> request)
        {
            var response = _spTermService.UpdateSPTerm(request);
            return Ok(response);
        }

        [HttpPost("GetSPTermListService")]
        public ActionResult<CommonResponseDto<List<SPTermDto>>> GetSPTermList([FromBody] CommonRequestDto<int> request)
        {
            var response = _spTermService.GetSPTermList(request);
            return Ok(response);
        }

        [HttpPost("GetSPTermService")]
        public ActionResult<CommonResponseDto<SPTermDto>> GetSPTermByGuid([FromBody] CommonRequestDto<Guid> request)
        {
            var response = _spTermService.GetSPTermByGuid(request);
            return Ok(response);
        }

        [HttpPost("GetSPTermDropdown")]
        public ActionResult<List<SPTermDto>> GetSPTermDropdown([FromBody] CommonRequestDto<int> req)
        {
           
                var result = _spTermService.GetSPTermDropdown(req);
                return Ok(result);
            }
        }
    
}