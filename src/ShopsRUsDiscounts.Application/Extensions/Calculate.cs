using System;
namespace ShopsRUsDiscounts.Application.Extensions
{
	public static class Calculate
	{
		public static decimal CalculateInvoiceDiscount(decimal price, decimal ratio)
		{
			decimal discount = (Math.Floor(price / 100) * ratio);
			return discount;
        }

	}
}

