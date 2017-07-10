using Beheerdersportaal.Api.Functionaliteiten.Vacatures;
using Beheerdersportaal.Api.Infrastructuur.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beheerdersportaal.Api.Functionaliteiten.Functies
{
    [Route("api/[controller]")]
    public class FunctiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = new GetFuncties.Request();
            var response = await Mediator.Send(request);
            return ToWebResponse(response);
        }

        [HttpGet]
        [Route("{functie}/vacatures")]
        public async Task<IActionResult> Get(int? functie)
        {
            var request = new GetVacatures.Request { Functie = functie };
            var response = await Mediator.Send(request);
            return ToWebResponse(response);
        }
    }
}
