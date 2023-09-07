using System;
using MediatR;
using ShopsRUsDiscounts.Application.Commands.Request;
using ShopsRUsDiscounts.Application.Commands.Response;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Interfaces;

namespace ShopsRUsDiscounts.Application.Handlers.CommandHendlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order
                {
                    Id = new Guid(),
                    CustomerId = request.CustomerId,
                    Price = request.OrderPrice,
                };
                _orderRepository.Add(order);
                
                return new CreateOrderCommandResponse
                {
                    IsSuccess = true,
                    OrderId = order.Id
                };
            }
            catch (Exception ex)
            {
                return new CreateOrderCommandResponse
                {
                    IsSuccess = true,
                    Message = ex.Message
                };
            }
        }
    }
}

