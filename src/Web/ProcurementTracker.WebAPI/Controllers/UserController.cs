using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcurementTracker.Application.Common.Pipelines.User;

namespace ProcurementTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [Authorize]
        [HttpPost("saveUser")]
        public async Task<IActionResult> SaveUser([FromBody] SaveUserCommand saveUserCommand)
        {
            var response = await _mediator.Send(saveUserCommand);

            return Ok(response);
        }
    }
}
