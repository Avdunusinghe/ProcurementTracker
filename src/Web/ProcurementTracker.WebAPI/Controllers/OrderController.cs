using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcurementTracker.Application.Common.Pipelines.Order.Command;
using ProcurementTracker.Application.Common.Pipelines.Order.Query;
using ProcurementTracker.Application.Common.Pipelines.PurchaseRequest.Command;
using ProcurementTracker.Application.Common.Pipelines.PurchaseRequest.Query;

namespace ProcurementTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        
        [Authorize]
        [HttpPost("saveOrder")]
        public async Task<IActionResult>SaveUser([FromBody] SaveOrderCommand saveOrderCommand)
        {
            var response = await _mediator.Send(saveOrderCommand);

            return Ok(response);
        }

        [Authorize]
        [HttpPost("savePurchaseRequest")]
        public async Task<IActionResult> SavePurchaseRequest([FromBody] SavePurchaseRequestCommand savePurchaseRequestCommand)
        {
            var response = await _mediator.Send(savePurchaseRequestCommand);

            return Ok(response);
        }

        [HttpPost("getOrders")]
        public async Task<IActionResult>GetAllOrders([FromBody] GetAllOrderQueryFilterAsyncCommand getAllOrderQueryFilterAsync)
        {
            var response = await _mediator.Send(getAllOrderQueryFilterAsync);

            return Ok(response);
        }

        [HttpPost("getPurchaseRequests")]
        public async Task<IActionResult> GetAllPurchaseRequests([FromBody] GetAllPurchaseRequestFilterQuery getAllPurchaseRequestFilterQuery)
        {
            var response = await _mediator.Send(getAllPurchaseRequestFilterQuery);

            return Ok(response);
        }
    }
}
