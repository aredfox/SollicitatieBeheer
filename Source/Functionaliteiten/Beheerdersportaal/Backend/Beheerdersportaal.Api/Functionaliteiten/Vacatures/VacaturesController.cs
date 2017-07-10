using Beheerdersportaal.Api.Infrastructuur.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beheerdersportaal.Api.Functionaliteiten.Vacatures
{
    [Route("api/[controller]")]
    public class VacaturesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get() {
            var request = new GetVacatures.Request();
            var response = await Mediator.Send(request);
            return ToWebResponse(response);
        }        
    }
}
