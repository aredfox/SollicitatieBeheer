using Beheerdersportaal.Api.Infrastructuur.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beheerdersportaal.Api.Functionaliteiten.Functies
{
    [Route("api/[controller]")]
    public class FunctiesController : BaseController
    {
        public FunctiesController(IMediator mediator) 
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> Get(GetFuncties.Request request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
