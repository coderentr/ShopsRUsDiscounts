using System;

namespace ShopsRUsDiscounts.Application.Queries.Response
{
	public class GetInvoiceQueryResponse
	{
		public int InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Description { get; set; }
        public Guid OrderId { get; set; }
    }
}

