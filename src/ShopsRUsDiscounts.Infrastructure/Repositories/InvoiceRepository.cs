using System;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Interfaces;
using ShopsRUsDiscounts.Infrastructure.Context;

namespace ShopsRUsDiscounts.Infrastructure.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        private readonly ShopsRUsDiscountsDBContext _dbContext;

        public InvoiceRepository(ShopsRUsDiscountsDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
            

        public Invoice GetInvoiceByInvoiceNumber(int invoiceNumber)
        {
            var invoice = _dbContext.Invoices.FirstOrDefault(_ => _.InvoiceNumber == invoiceNumber);
            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }
            return invoice;
        }
    }
}

