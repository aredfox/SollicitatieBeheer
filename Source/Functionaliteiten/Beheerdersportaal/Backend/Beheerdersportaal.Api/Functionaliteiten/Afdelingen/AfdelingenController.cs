using Beheerdersportaal.Api.Infrastructuur.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beheerdersportaal.Api.Functionaliteiten.Afdelingen
{
    [Route("api/[controller]")]
    public class AfdelingenController : BaseController
    {
        public AfdelingenController(IMediator mediator) 
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> Get(GetAfdelingen.Request request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
