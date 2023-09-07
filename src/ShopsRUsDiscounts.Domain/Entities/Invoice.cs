using System;
namespace ShopsRUsDiscounts.Domain.Entities
{
	public class Invoice : BaseEntity
	{
		public int InvoiceNumber { get; set; }
        public virtual Customer Customer { get; set; }
		public decimal InvoiceAmount { get; set; }
		public decimal DiscountAmount { get; set; }
		public decimal TotalAmount { get; set; }
		public string Description { get; set; }
    }
}

