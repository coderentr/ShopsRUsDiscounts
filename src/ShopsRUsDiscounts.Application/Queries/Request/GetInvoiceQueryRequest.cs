using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using ShopsRUsDiscounts.Application.Queries.Response;

namespace ShopsRUsDiscounts.Application.Queries.Request
{
	public class GetInvoiceQueryRequest : IRequest<BaseQueryResponse<GetInvoiceQueryResponse>>
    {
        [Required(ErrorMessage = "InvoiceNumber must be entry.")]
        public int InvoiceNumber { get; set; }
	}
}

