using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConnectaSummer.Application.AccountHolders.Requests;
using ConnectaSummer.Domain.Users;
using System;

namespace ConnectaSummer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AccountHolderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        //[Authorize(Roles = nameof(ConnectaSummer.Domain.Users.User.CreateHolderAccount))]
        //[Authorize(Roles = nameof(ConnectaSummer.Domain.Users.User.DeleteHolderAccount))]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok();
        //}
        public async Task<IActionResult> Get([FromQuery] AccountHolderRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(await Task.FromResult(response));
        }

        [HttpPost]
        [Authorize(Roles = nameof(ConnectaSummer.Domain.Users.CreateAccountHolder) + "," + nameof(ConnectaSummer.Domain.Users.CreateAccountHolder))] // 1 ou outro
        public IActionResult Post([FromBody] CreateAccountHolderRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(Roles = nameof(ConnectaSummer.Domain.Users.CreateAccountHolder) + "," + nameof(ConnectaSummer.Domain.Users.CreateAccountHolder))] // 1 ou outro
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateAccountHolderRequest request)
        {
            request.SetId(id);
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(Roles = nameof(ConnectaSummer.Domain.Users.CreateAccountHolder) + "," + nameof(ConnectaSummer.Domain.Users.CreateAccountHolder))] // 1 ou outro
        public IActionResult Remove([FromRoute] Guid id, [FromBody] DeleteAccountHolderRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(Task.FromResult(response));
        }
    }
}
