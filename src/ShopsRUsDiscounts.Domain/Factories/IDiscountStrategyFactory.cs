using System;
namespace ShopsRUsDiscounts.Domain.Interfaces
{
	public interface IDiscountStrategyFactory
	{
        decimal CalculateDiscount(decimal price);
	}

    public class EmployeDiscountStrategy : IDiscountStrategyFactory
    {
        private decimal _ratio;

        public EmployeDiscountStrategy(decimal ratio)
        {
            _ratio = ratio;
        }

        public decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice - (originalPrice * (_ratio / 100));
        }
    }
    public class AffiliateOfStoreDiscountStrategy : IDiscountStrategyFactory
    {
        private decimal _ratio;

        public AffiliateOfStoreDiscountStrategy(decimal ratio)
        {
            _ratio = ratio;
        }

        public decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice - (originalPrice * (_ratio / 100));
        }
    }
    public class OldCustomerDiscountStrategy : IDiscountStrategyFactory
    {
        private decimal _ratio;

        public OldCustomerDiscountStrategy(decimal ratio)
        {
            _ratio = ratio;
        }

        public decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice - (originalPrice * (_ratio / 100));
        }
    }

    public class MoDiscountStrategy : IDiscountStrategyFactory
    {
        public MoDiscountStrategy()
        {

        }
        public decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice;
        }
    }
}

