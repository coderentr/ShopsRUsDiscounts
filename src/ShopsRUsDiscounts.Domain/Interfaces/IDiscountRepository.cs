using System;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Enums;

namespace ShopsRUsDiscounts.Domain.Interfaces
{
	public interface IDiscountRepository :IRepository<Discount>
	{
		Discount GetDiscountByCustomerType(CustomerType customerType);
	}
}

