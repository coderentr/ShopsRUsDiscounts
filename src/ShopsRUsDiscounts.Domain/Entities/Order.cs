using System;
namespace ShopsRUsDiscounts.Domain.Entities
{
	public class Order : BaseEntity
	{
		public virtual Customer Customer { get; set; }
        public decimal Price { get; set; }
		public decimal DicountedPrice { get; set; }
    }
}

