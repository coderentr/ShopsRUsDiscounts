using System;
using MediatR;
using ShopsRUsDiscounts.Application.Commands.Response;

namespace ShopsRUsDiscounts.Application.Commands.Request
{
	public class CreateOrderCommandRequest :IRequest<CreateOrderCommandResponse>
	{
		public Guid CustomerId { get; set; }
		public decimal OrderPrice { get; set; }
	}
}

