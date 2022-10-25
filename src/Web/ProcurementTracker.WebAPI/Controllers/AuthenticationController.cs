using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcurementTracker.Application.Common.Pipelines.User;

namespace ProcurementTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationCommand authenticationCommand)
        {
            var response = await _mediator.Send(authenticationCommand);

            return Ok(response);
        }
    }
}
