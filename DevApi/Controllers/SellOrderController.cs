using Microsoft.AspNetCore.Mvc;
using DevApi.Models;
using DevApi.Models.Common;
using DevApi.BAL;
using System.Collections.Generic;


namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellOrderController : ControllerBase
    {
        private readonly SellOrderService _sellOrderService;

        public SellOrderController(SellOrderService sellOrderService)
        {
            _sellOrderService = sellOrderService;
        }

        [HttpPost("SaveSellOrderService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> SaveSellOrder([FromBody] CommonRequestDto<SellOrderReqDto> request)
        {
            var response = _sellOrderService.SaveSellOrder(request);
            return Ok(response);
        }

        [HttpPost("GetSellOrderListService")]
        public ActionResult<CommonResponseDto<List<SellOrderListDto>>> GetSellOrderList([FromBody] CommonRequestDto<int> request)
        {
            var response = _sellOrderService.GetSellOrderList(request);
            return Ok(response);
        }
        [HttpPost("UpdateSellOrderService")]
        public ActionResult<CommonResponseDto<SellOrderListDto>> GetSellOrderList([FromBody] CommonRequestDto<SellOrderUpdateDto> request)
        {
            var response = _sellOrderService.UpdateSellOrder(request);
            return Ok(response);
        }
        [HttpPost("MaxSellOrderNoService")]
        public ActionResult<CommonResponseDto<MaxSellOrderNoDto>> GetMaxSellOrderNo([FromBody] CommonRequestDto<int> request)
        {
            var response = _sellOrderService.MaxSellORderNo(request);
            return Ok(response);
        }

        [HttpPost("UpdatePaymentSellOrderService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> UpdatePaymentSellOrder([FromBody] CommonRequestDto<UpdateSellOrderPaymentDto> request)
        {
            var response = _sellOrderService.UpdatePaymentSellOrder(request);
            return Ok(response);
        }

        [HttpPost("ViewSellOrderService")]
        public ActionResult<CommonResponseDto<SellOrderViewDto>> SellOrderView([FromBody] CommonRequestDto<Guid> request)
        {
            var response = _sellOrderService.SellOrderView(request);
            return Ok(response);
        }

    }
}
