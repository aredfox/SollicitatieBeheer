using Beheerdersportaal.Api.Infrastructuur.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Beheerdersportaal.Api.Infrastructuur.Controllers
{
    public abstract class BaseController : Controller
    {
        public IMediator Mediator { get; set; }

        protected IActionResult ToWebResponse<TResponse>(TResponse response)
            where TResponse : BaseResponse
        {
            if (response == null)
            {
                var baseResponse = new BaseResponse {
                    HasSucceeded = false,
                    Error = "Niet gevonden"
                };
                return NotFound(baseResponse);
            }

            if (response is Exception exception)
            {
                var baseResponse = new BaseResponse {
                    HasSucceeded = false,
                    Error = exception.Message
                };
                return BadRequest(baseResponse);
            }            

            return Ok(response);
        }
    }
}
