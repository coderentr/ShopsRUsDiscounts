using System;
namespace ShopsRUsDiscounts.Application.Commands.Response
{
	public class CreateOrderCommandResponse : BaseCommandResponse
	{
		public Guid OrderId { get; set; }
	}
}

