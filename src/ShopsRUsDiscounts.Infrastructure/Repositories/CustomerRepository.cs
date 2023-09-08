using System;
using ShopsRUsDiscounts.Domain.Entities;
using ShopsRUsDiscounts.Domain.Interfaces;
using ShopsRUsDiscounts.Infrastructure.Context;

namespace ShopsRUsDiscounts.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopsRUsDiscountsDBContext dbContext) : base(dbContext)
        {
        }
    }
}

