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

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> LijstVacaturesOp(LijstVacaturesOp.Request request) {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> WijzigVacature(WijzigVacature.Request request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
