using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopsRUsDiscounts.Application.Queries.Request;
using ShopsRUsDiscounts.Application.Queries.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopsRUsDiscounts.Api.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : BaseApiController
    {
        public InvoiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Get")]
        public async Task<IActionResult> Invoice([FromQuery] GetInvoiceQueryRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BaseQueryResponse<GetInvoiceQueryResponse> response = await _mediator.Send(request);
                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

