using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcurementTracker.Application.Common.Pipelines.MasterData;
using ProcurementTracker.Application.Common.Pipelines.MasterData.Query;

namespace ProcurementTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MasterDataController(IMediator mediator)
        {
            this._mediator = mediator;
        }

       
       
        [HttpGet("getSupplierMasterData")]
        public async Task<IActionResult> GetSupplierMasterData()
        {
            var response = await _mediator.Send(new SupplierMasterDataQuery());

            return Ok(response);
        }

        [HttpGet("getProductMasterData")]
        public async Task<IActionResult> GetProductMasterData()
        {
            var response = await _mediator.Send(new ProductMasterDataQuery());

            return Ok(response);
        }

        [HttpGet("getOrderStatusMasterData")]
        public async Task<IActionResult> GetOrderStatusMasterData()
        {
            var response = await _mediator.Send(new OrderStatusMasterDataQuery());

            return Ok(response);
        }

    }
}
