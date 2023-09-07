using System;
namespace ShopsRUsDiscounts.Domain.Entities
{
	public class Order : BaseEntity
	{
		public Guid CustomerId { get; set; }
        public decimal Price { get; set; }
		public decimal DicountPrice { get; set; }
    }
}

