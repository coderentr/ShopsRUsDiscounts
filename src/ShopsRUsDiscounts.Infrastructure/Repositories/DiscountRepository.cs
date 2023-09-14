using System;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Enums;
using ShopsRUsDiscounts.Domain.Interfaces;
using ShopsRUsDiscounts.Infrastructure.Context;

namespace ShopsRUsDiscounts.Infrastructure.Repositories
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        private readonly ShopsRUsDiscountsDBContext _dbContext;

        public DiscountRepository(ShopsRUsDiscountsDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Discount GetDiscountByCustomerType(CustomerType customerType)
        {
            var discount = _dbContext.Discounts.FirstOrDefault(_ => _.CustomerType == customerType);
            if (discount == null)
            {
                throw new Exception("Discount not found");
            }
            return discount;
        }
    }
}

