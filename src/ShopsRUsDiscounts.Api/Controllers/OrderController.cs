using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopsRUsDiscounts.Application.Commands.Request;
using ShopsRUsDiscounts.Application.Commands.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopsRUsDiscounts.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : BaseApiController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request)
        {
            try
            {
                CreateOrderCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

