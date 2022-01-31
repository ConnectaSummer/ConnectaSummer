using ConnectaSummer.Application.Extracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConnectaSummer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtractController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExtractController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ExtractRequest request)
        {
            var response = _mediator.Send(request);
            return Ok(await Task.FromResult(response));
        }
    }
}