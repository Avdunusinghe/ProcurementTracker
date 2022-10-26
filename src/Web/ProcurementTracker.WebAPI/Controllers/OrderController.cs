using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcurementTracker.Application.Common.Pipelines.Order.Command;

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
        public async Task<IActionResult> SaveUser([FromBody] SaveOrderCommand saveOrderCommand)
        {
            var response = await _mediator.Send(saveOrderCommand);

            return Ok(response);
        }
    }
}
