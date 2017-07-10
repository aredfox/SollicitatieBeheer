using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Beheerdersportaal.Api.Infrastructuur.Controllers
{
    public abstract class BaseController : Controller
    {
        public IMediator Mediator { get; set; }

        protected IActionResult ToWebResponse<TResponse>(TResponse response) 
        {
            if (response == null)
                return NotFound();

            if (response is Exception exception)
                return BadRequest(exception.Message);

            return Ok(response);
        }
    }
}
