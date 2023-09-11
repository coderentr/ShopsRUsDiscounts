using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsRUsDiscounts.Domain.Entities
{
	public class Invoice : BaseEntity
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNumber { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
        public decimal InvoiceAmount { get; set; }
		public decimal? DiscountAmount { get; set; }
		public decimal TotalAmount { get; set; }
		public string? Description { get; set; }
    }
}

