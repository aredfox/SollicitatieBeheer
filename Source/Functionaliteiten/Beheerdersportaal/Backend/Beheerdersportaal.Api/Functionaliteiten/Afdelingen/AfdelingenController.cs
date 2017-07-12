using Beheerdersportaal.Api.Functionaliteiten.Vacatures;
using Beheerdersportaal.Api.Infrastructuur.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beheerdersportaal.Api.Functionaliteiten.Afdelingen
{
    [Route("api/[controller]")]
    public class AfdelingenController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(GetAfdelingen.GetAfdelingenRequest request)
        {
            var response = await Mediator.Send(request);
            return ToWebResponse(response);            
        }

        [HttpGet]
        [Route("{afdeling}/vacatures")]
        public async Task<IActionResult> Get(int? afdeling)
        {
            var request = new GetVacatures.Request { Afdeling = afdeling };
            var response = await Mediator.Send(request);
            return ToWebResponse(response);
        }
    }
}
