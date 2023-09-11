using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using ShopsRUsDiscounts.Application.Commands.Response;

namespace ShopsRUsDiscounts.Application.Commands.Request
{
	public class CreateOrderCommandRequest :IRequest<CreateOrderCommandResponse>
	{
        [Required(ErrorMessage = "CustomerId must be entry.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "OrderPrice must be entry.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Field must be greater than 0.")]
        public decimal OrderPrice { get; set; }
	}
}

