using Moq;
using NUnit.Framework;
using ShopsRUsDiscounts.Application.Commands.Request;
using ShopsRUsDiscounts.Application.Handlers.CommandHendlers;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Interfaces;
using ShopsRUsDiscounts.Domain.Events;
using ShopsRUsDiscounts.Domain.Enums;

namespace ShopsRUsDiscounts.Application.Tests.Handlers
{
    [TestFixture]
    public class CreateOrderCommandHandlerTests
    {
        [Test]
        public void Handle_ValidRequest_ReturnsSuccessResponse()
        {
            var customerId = new Guid("cb2a620c-6610-49f2-930b-798cb83af812");
            var orderPrice = 100.0m;
            var customer = new Customer { Id = customerId, CustomerType = CustomerType.Employee, FullName = "Test Customer" };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(repo => repo.GetById(customerId)).Returns(customer);

            var orderRepositoryMock = new Mock<IOrderRepository>();
            var eventPublishMock = new Mock<IEventPublish>();
            var discountRepositoryMock = new Mock<IDiscountRepository>();

            var handler = new CreateOrderCommandHandler(orderRepositoryMock.Object, customerRepositoryMock.Object, eventPublishMock.Object, discountRepositoryMock.Object);
            var request = new CreateOrderCommandRequest { CustomerId = customerId, OrderPrice = orderPrice };

            var response = handler.Handle(request, CancellationToken.None).Result;

            NUnit.Framework.Assert.IsTrue(response.IsSuccess);
            NUnit.Framework.Assert.IsNotNull(response.OrderId);
        }

        [Test]
        public void Handle_CustomerNotFound_ReturnsErrorResponse()
        {
            var customerId = Guid.NewGuid();
            var orderPrice = 100.0m;

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(repo => repo.GetById(customerId)).Returns((Customer)null);

            var orderRepositoryMock = new Mock<IOrderRepository>();
            var eventPublishMock = new Mock<IEventPublish>();
            var discountRepositoryMock = new Mock<IDiscountRepository>();

            var handler = new CreateOrderCommandHandler(orderRepositoryMock.Object, customerRepositoryMock.Object, eventPublishMock.Object, discountRepositoryMock.Object);
            var request = new CreateOrderCommandRequest { CustomerId = customerId, OrderPrice = orderPrice };

            var response = handler.Handle(request, CancellationToken.None).Result;

            NUnit.Framework.Assert.IsFalse(response.IsSuccess);
            NUnit.Framework.Assert.AreEqual("Customer couldn fount !", response.Message);
        }

    }
}
