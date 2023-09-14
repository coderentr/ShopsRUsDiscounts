using System;
using Moq;
using NUnit.Framework;
using ShopsRUsDiscounts.Application.Handlers.QueryHandlers;
using ShopsRUsDiscounts.Application.Queries.Request;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Interfaces;

namespace ShopsRUsDiscounts.Application.Tests.Handlers.QueryHandlers
{
    [TestFixture]
    public class GetInvoiceQueryHandlerTests
    {
        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessResponseWithData()
        {
            int invoiceNumber = 1234;
            var invoiceData = new Invoice
            {
                Id=new Guid(),
                InvoiceNumber = invoiceNumber,
                InvoiceAmount = 1000, 
            };

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(repo => repo.GetInvoiceByInvoiceNumber(invoiceNumber)).Returns(invoiceData);

            var handler = new GetInvoiceQueryHandler(invoiceRepositoryMock.Object);
            var request = new GetInvoiceQueryRequest { InvoiceNumber = invoiceNumber };

            var response = await handler.Handle(request, CancellationToken.None);

            NUnit.Framework.Assert.IsTrue(response.IsSuccess);
            NUnit.Framework.Assert.IsNotNull(response.Data);
            NUnit.Framework.Assert.AreEqual(invoiceData.InvoiceNumber, response.Data.InvoiceNumber);
            NUnit.Framework.Assert.AreEqual(invoiceData.InvoiceAmount, response.Data.InvoiceAmount);
        }

        [Test]
        public async Task Handle_InvoiceNotFound_ReturnsErrorResponse()
        {
            int invoiceNumber = 1234;

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(repo => repo.GetInvoiceByInvoiceNumber(invoiceNumber)).Returns((Invoice)null);

            var handler = new GetInvoiceQueryHandler(invoiceRepositoryMock.Object);
            var request = new GetInvoiceQueryRequest { InvoiceNumber = invoiceNumber };

            var response = await handler.Handle(request, CancellationToken.None);

            NUnit.Framework.Assert.IsFalse(response.IsSuccess);
            NUnit.Framework.Assert.IsNull(response.Data);
            NUnit.Framework.Assert.AreEqual("Invoice not found", response.Message);
        }

        [Test]
        public async Task Handle_ExceptionThrown_ReturnsErrorResponse()
        {
            int invoiceNumber = 1234;

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(repo => repo.GetInvoiceByInvoiceNumber(invoiceNumber)).Throws(new Exception("Simulated exception"));

            var handler = new GetInvoiceQueryHandler(invoiceRepositoryMock.Object);
            var request = new GetInvoiceQueryRequest { InvoiceNumber = invoiceNumber };

            var response = await handler.Handle(request, CancellationToken.None);

            NUnit.Framework.Assert.IsFalse(response.IsSuccess);
            NUnit.Framework.Assert.IsNull(response.Data);
            NUnit.Framework.Assert.AreEqual("An unexpected error occurred.", response.Message);
        }
    }
}
