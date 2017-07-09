using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beheerdersportaal.Api.Functionaliteiten.Vacatures
{
    [Route("api/[controller]")]
    public class VacaturesController : Controller
    {
        private readonly IMediator _mediator;

        public VacaturesController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LijstVacaturesOp(LijstVacaturesOp.Request request) {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
