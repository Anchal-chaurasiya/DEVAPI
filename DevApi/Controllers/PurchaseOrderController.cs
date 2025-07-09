using Microsoft.AspNetCore.Mvc;
using DevApi.Models;
using DevApi.Models.Common;
using DevApi.BAL;

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

        [HttpPost("SavePurchaseOrder")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> SavePurchaseOrder([FromBody] CommonRequestDto<PurchaseOrderReqDto> request)
        {
            var response = _purchaseOrderService.SavePurchaseOrder(request);
            return Ok(response);
        }
    }
}