using System;
using ShopsRUsDiscounts.Domain.Entities;

namespace ShopsRUsDiscounts.Domain.Interfaces
{
	public interface IInvoiceRepository : IRepository<Invoice>
    {
		Invoice GetInvoiceByInvoiceNumber(int invoiceNumber);
	}
}

