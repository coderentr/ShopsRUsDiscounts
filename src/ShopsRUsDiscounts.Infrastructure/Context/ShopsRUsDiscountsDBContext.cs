using System;
using Microsoft.EntityFrameworkCore;
using ShopsRUsDiscounts.Domain.Entities;

namespace ShopsRUsDiscounts.Infrastructure.Context
{
	public class ShopsRUsDiscountsDBContext : DbContext
    {
        public ShopsRUsDiscountsDBContext(DbContextOptions<ShopsRUsDiscountsDBContext> options)
          : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

