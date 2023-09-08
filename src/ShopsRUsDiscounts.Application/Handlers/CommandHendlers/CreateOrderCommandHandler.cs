using MediatR;
using ShopsRUsDiscounts.Application.Commands.Request;
using ShopsRUsDiscounts.Application.Commands.Response;
using ShopsRUsDiscounts.Application.Extensions;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Interfaces;

namespace ShopsRUsDiscounts.Application.Handlers.CommandHendlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        IOrderRepository _orderRepository;
        ICustomerRepository _customerRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerRepository.GetById(request.CustomerId);
                if (customer is not null)
                {
                    var discountStrategy = DiscountHelper.GetDiscountStrategy(customer.CustomerType);
                    var discountPrice= discountStrategy.CalculateDiscount(request.OrderPrice);

                    var order = new Order
                    {
                        Id = new Guid(),
                        CustomerId = request.CustomerId,
                        Price = request.OrderPrice,
                        DicountPrice = discountPrice,
                    };
                    _orderRepository.Add(order);


                    return new CreateOrderCommandResponse
                    {
                        IsSuccess = true,
                        OrderId = order.Id
                    };
                }


                return new CreateOrderCommandResponse
                {
                    IsSuccess = false,
                    Message = "Customer couldn fount !"
                };
            }
            catch (Exception ex)
            {
                return new CreateOrderCommandResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}

