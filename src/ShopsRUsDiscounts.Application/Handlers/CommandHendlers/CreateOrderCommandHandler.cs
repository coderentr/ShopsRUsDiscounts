using MediatR;
using ShopsRUsDiscounts.Application.Commands.Request;
using ShopsRUsDiscounts.Application.Commands.Response;
using ShopsRUsDiscounts.Application.Extensions;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Events;
using ShopsRUsDiscounts.Domain.Interfaces;

namespace ShopsRUsDiscounts.Application.Handlers.CommandHendlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventPublish _eventPublish;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository, IEventPublish eventPublish)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _eventPublish = eventPublish;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerRepository.GetById(request.CustomerId);
                if (customer is not null)
                {
                    var discountStrategy = DiscountHelper.GetDiscountStrategy(customer.CustomerType);
                    decimal discountPrice= discountStrategy.CalculateDiscount(request.OrderPrice);

                    Order order = new Order
                    {
                        Id = Guid.NewGuid(),
                        Customer = customer,
                        Price = request.OrderPrice,
                        DicountPrice = discountPrice,
                    };
                    _orderRepository.Add(order);

                    decimal invoiceDiscountAmount = Calculate.CalculateInvoiceDiscount(discountPrice, 5);
                    decimal incoiceAmount = order.Price - invoiceDiscountAmount;

                    _eventPublish.Publish(new SyncInvoiceEvent {
                        Invoice = new Invoice {
                            Id = Guid.NewGuid(),
                            OrderId = order.Id,
                            Description=$"{customer.FullName}'s invoice",
                            DiscountAmount= invoiceDiscountAmount,
                            InvoiceAmount = incoiceAmount,
                            TotalAmount=order.Price,
                            CreaatedDate=DateTime.Now
                        }
                    });

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

