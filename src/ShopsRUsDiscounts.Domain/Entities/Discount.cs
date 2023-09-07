using System;
using ShopsRUsDiscounts.Domain.Enums;

namespace ShopsRUsDiscounts.Domain.Entities
{
	public class Discount 
	{
		public int Id { get; set; }
		public float DiscountRatio { get; set; }
		public CustomerType CustomerType { get; set; }
	}
}

