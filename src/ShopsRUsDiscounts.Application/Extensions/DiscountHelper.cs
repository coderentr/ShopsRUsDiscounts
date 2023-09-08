using System;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Enums;
using ShopsRUsDiscounts.Domain.Interfaces;

namespace ShopsRUsDiscounts.Application.Extensions
{
	public static class DiscountHelper
	{
        public static IDiscountStrategyFactory GetDiscountStrategy(CustomerType type)
        {
            if (type == CustomerType.Employee)
            {
                return new EmployeDiscountStrategy(30); 
            }
            else if (type == CustomerType.AffiliateOfStore)
            {
                return new EmployeDiscountStrategy(10); 
            }
            else if (type == CustomerType.OldCustomer)
            {
                return new EmployeDiscountStrategy(5);
            }
            else
            {
                return new MoDiscountStrategy(); // Diğer müşterilere indirim yok
            }
        }
    }
}

