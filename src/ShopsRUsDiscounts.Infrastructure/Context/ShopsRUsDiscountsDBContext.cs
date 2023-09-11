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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = Guid.NewGuid(), CreaatedDate=DateTime.Now,CustomerType=Domain.Enums.CustomerType.Standard, Email="a@a.com", FullName="mustafa eren"},
                new Customer { Id = Guid.NewGuid(), CreaatedDate=DateTime.Now,CustomerType=Domain.Enums.CustomerType.AffiliateOfStore, Email="b@a.com", FullName="ali eren"},
                new Customer { Id = Guid.NewGuid(), CreaatedDate=DateTime.Now,CustomerType=Domain.Enums.CustomerType.Employee, Email="b@a.com", FullName="veli eren"},
                new Customer { Id = Guid.NewGuid(), CreaatedDate=DateTime.Now,CustomerType=Domain.Enums.CustomerType.OldCustomer, Email="b@a.com", FullName="aayşe eren"}
              );
        }
    }
}

