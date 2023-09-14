using System;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Enums;
using ShopsRUsDiscounts.Domain.Interfaces;

namespace ShopsRUsDiscounts.Application.Extensions
{
	public static class DiscountHelper
	{
        public static IDiscountStrategyFactory GetDiscountStrategy(CustomerType type, decimal ratio)
        {
            if (type == CustomerType.Employee)
            {
                return new EmployeDiscountStrategy(ratio); 
            }
            else if (type == CustomerType.AffiliateOfStore)
            {
                return new AffiliateOfStoreDiscountStrategy(ratio); 
            }
            else if (type == CustomerType.OldCustomer)
            {
                return new OldCustomerDiscountStrategy(ratio);
            }
            else
            {
                return new MoDiscountStrategy(); // Diğer müşterilere indirim yok
            }
        }
    }
}

