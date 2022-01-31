using ConnectaSummer.Application.Operation.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //[Authorize(Roles = nameof(Domain.Users.User.CreateHolderAccount))] 
        public IActionResult Post([FromBody] WithdrawRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("deposit")]
        //[Authorize(Roles = nameof(Domain.Users.User.CreateHolderAccount))] 
        public IActionResult Post([FromBody] DepositRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }

    }
}
