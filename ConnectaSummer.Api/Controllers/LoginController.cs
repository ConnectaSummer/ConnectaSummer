using ConnectaSummer.Api.Statcs;
using ConnectaSummer.Application.Users.Requests;
using ConnectaSummer.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [Authorize]
        public IActionResult Post(CreateUserRequest request)
        {
            var response = _mediator.Send(request).Result;
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult GenerateToken(string user, string pass)
        {
            return Ok(
                    new
                    {
                        StatusCode = 200,
                        Token = TokenService.GenerateToken(new User(user, pass)),
                        User = user,
                        ExpireDate = DateTime.Now.AddHours(2)
                    }
                );
        }


    }
}
