using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConnectaSummer.Application.AccountHolders.Requests;
using ConnectaSummer.Domain.Users;
using System;
using ConnectaSummer.Application.Account.Requests;

namespace ConnectaSummer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AccountRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(await Task.FromResult(response));
        }

        [HttpPost]
        [Authorize(Roles = nameof(Domain.Users.User.CreateHolderAccount))] 
        public IActionResult Post([FromBody] CreateAccountRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(Roles = nameof(Domain.Users.User.CreateHolderAccount))]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateAccountRequest request)
        {
            request.SetId(id);
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(Roles = nameof(Domain.Users.User.CreateHolderAccount))]
        public IActionResult Remove([FromRoute] Guid id, [FromBody] DeleteAccountRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(Task.FromResult(response));
        }
    }
}
