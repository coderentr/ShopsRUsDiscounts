using System;
using System.ComponentModel.DataAnnotations;
using ShopsRUsDiscounts.Domain.Enums;

namespace ShopsRUsDiscounts.Domain.Entities
{
	public class Discount :BaseEntity
	{
		public decimal DiscountRatio { get; set; }

        [Required]
        public CustomerType CustomerType { get; set; }
	}
}

