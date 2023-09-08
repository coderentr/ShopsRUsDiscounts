using System;
namespace ShopsRUsDiscounts.Application.Extensions
{
	public static class Calculate
	{
		public static decimal CalculateOrder(decimal price, decimal ratio)
		{
			return price * (ratio / 100);
		}
	}
}

