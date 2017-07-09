using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Beheerdersportaal.Api.Infrastructuur.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator) => _mediator = mediator;
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
