using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using DevApi.Models.Common;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost("AddCustomerService")]
        public IActionResult AddCustomer([FromBody] CommonRequestDto<CustomerSaveDto> request)
        {
            var result = customerService.SaveCustomer(request);
            return result.Flag == 1 ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetCustomerListService")]
        public ActionResult<CommonResponseDto<List<CustomerListDto>>> GetCustomerList([FromBody] CommonRequestDto<int> request)
        {
            var result = customerService.GetCustomerList(request);
            return Ok(result);
        }
        [HttpPost("GetCustomerService")]
        public ActionResult<CommonResponseDto<CustomerSaveDto>> GetCustomerByGuid([FromBody] CommonRequestDto<Guid> request)
        {
            var result = customerService.GetCustomerByGuid(request);
            return Ok(result);
        }

        [HttpPost("GetCustomerListForDropDownService")]
        public ActionResult<CommonResponseDto<CustomerList>> GetCustomerForDropdown([FromBody] CommonRequestDto<CustomerReqDto> request)
        {
            var result = customerService.GetCustomerListForDropdown(request);
            return Ok(result);
        }
        [HttpPost("GetCustomerAddressService")]
        public ActionResult<CommonResponseDto<CustomerListAddrrss>> GetCustomerAddress([FromBody] CommonRequestDto<CustomerReqDto> request)
        {
            var result = customerService.GetCustomerAddress(request);
            return Ok(result);
        }
    }
}