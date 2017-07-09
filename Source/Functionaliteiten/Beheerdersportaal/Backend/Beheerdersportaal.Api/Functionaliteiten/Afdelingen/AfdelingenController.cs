using Beheerdersportaal.Api.Functionaliteiten.Vacatures;
using Beheerdersportaal.Api.Infrastructuur.Controllers;
using Beheerdersportaal.Model.Afdelingen;
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
            return ToWebResponse(response);            
        }

        [HttpGet]
        [Route("{afdeling}/vacatures")]
        public async Task<IActionResult> Get(int? afdeling)
        {
            var request = new GetVacatures.Request { Afdeling = afdeling };
            var response = await _mediator.Send(request);
            return ToWebResponse(response);
        }
    }
}
