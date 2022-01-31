using ConnectaSummer.Application.Operation.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ConnectaSummer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {

        private readonly IMediator _mediator;
        public OperationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("withdraw")]
        [Authorize]
        public IActionResult Post([FromBody] WithdrawRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("deposit")]
        [Authorize]
        public IActionResult Post([FromBody] DepositRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }

    }
}
