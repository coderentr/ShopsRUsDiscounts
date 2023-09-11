using System;
using MassTransit;
using ShopsRUsDiscounts.Domain.Events;
using ShopsRUsDiscounts.Infrastructure.Context;

namespace ShopsRUsDiscounts.Infrastructure.Cunsomers
{
    public class SyncCreateInvoiceCunsomer : IConsumer<SyncInvoiceEvent>
    {
        private readonly ShopsRUsDiscountsDBContext _context;

        public SyncCreateInvoiceCunsomer(ShopsRUsDiscountsDBContext context)
        {
            _context = context;
        }

        public  async Task Consume(ConsumeContext<SyncInvoiceEvent> context)
        {
            await _context.Invoices.AddAsync(context.Message.Invoice);
            _context.SaveChanges();
        }
    }
}

