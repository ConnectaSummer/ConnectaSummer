using ConnectaSummer.Api.Statcs;
using ConnectaSummer.Application.Login.Requests;
using ConnectaSummer.Application.Login.Responses;
using ConnectaSummer.Application.Users.Requests;
using ConnectaSummer.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConnectaSummer.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : Controller
    {
        IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-user")]
        [Authorize]
        public IActionResult Post(CreateUserRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken(LoginRequest request)
        {
            LoginResponse response = await _mediator.Send(request);
            if (response.StatusCode == 200)
            {
                response.Token = TokenService.GenerateToken(new User(request.Login, request.Pass));
                response.Message = "token generated successfully!!!";
            }
            return StatusCode(response.StatusCode, response);
        }

    }
}
