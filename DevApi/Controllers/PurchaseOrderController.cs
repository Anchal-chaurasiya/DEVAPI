using Microsoft.AspNetCore.Mvc;
using DevApi.Models;
using DevApi.Models.Common;
using DevApi.BAL;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly PurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(PurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpPost("SavePurchaseOrderService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> SavePurchaseOrder([FromBody] CommonRequestDto<PurchaseOrderReqDto> request)
        {
            var response = _purchaseOrderService.SavePurchaseOrder(request);
            return Ok(response);
        }

        [HttpPost("GetPurchaseOrderListService")]
        public ActionResult<CommonResponseDto<List<PurchaseOrderListDto>>> GetPurchaseOrderList([FromBody] CommonRequestDto<int> request)
        {
            var response = _purchaseOrderService.GetPurchaseOrderList(request);
            return Ok(response);
        }
        [HttpPost("UpdatePurchaseOrderService")]
        public ActionResult<CommonResponseDto<PurchaseOrderListDto>> GetPurchaseOrderList([FromBody] CommonRequestDto<PurchaseOrderUpdateDto> request)
        {
            var response = _purchaseOrderService.UpdatePurchaseOrder(request);
            return Ok(response);
        }
        [HttpPost("MaxPurchaseOrderNoService")]
        public ActionResult<CommonResponseDto<MaxPurchaseOrderNoDto>> GetMaxPurchaseOrderNo([FromBody] CommonRequestDto<int> request)
        {
            var response = _purchaseOrderService.MaxPurchaseORderNo(request);
            return Ok(response);
        }

        [HttpPost("UpdatePaymentPurchaseOrderService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> UpdatePaymentPurchaseOrder([FromBody] CommonRequestDto<UpdatePurchaseOrderPaymentDto> request)
        {
            var response = _purchaseOrderService.UpdatePaymentPurchaseOrder(request);
            return Ok(response);
        }



    }
}