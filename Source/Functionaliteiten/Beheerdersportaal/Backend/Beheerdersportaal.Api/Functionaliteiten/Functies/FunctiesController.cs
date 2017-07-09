using Beheerdersportaal.Api.Functionaliteiten.Vacatures;
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
        public async Task<IActionResult> Get()
        {
            var request = new GetFuncties.Request();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{functie}/vacatures")]
        public async Task<IActionResult> Get(int? functie)
        {
            var request = new GetVacatures.Request { Functie = functie };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
