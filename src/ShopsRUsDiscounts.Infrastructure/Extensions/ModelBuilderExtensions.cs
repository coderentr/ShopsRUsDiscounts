using System;
using Microsoft.EntityFrameworkCore;
using ShopsRUsDiscounts.Domain.Entities;

namespace ShopsRUsDiscounts.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.Standard, Email = "a@a.com", FullName = "mustafa eren", IsActive=true, IsDelete=false },
                new Customer { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.AffiliateOfStore, Email = "b@a.com", FullName = "ali eren", IsActive = true, IsDelete = false },
                new Customer { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.Employee, Email = "b@a.com", FullName = "veli eren", IsActive = true, IsDelete = false },
                new Customer { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.OldCustomer, Email = "b@a.com", FullName = "aayşe eren", IsActive = true, IsDelete = false }
              );
            modelBuilder.Entity<Discount>().HasData(
                new Discount { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.Standard, DiscountRatio = 0, IsActive = true, IsDelete = false },
                new Discount { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.AffiliateOfStore, DiscountRatio = 10, IsActive = true, IsDelete = false },
                new Discount { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.Employee, DiscountRatio = 30, IsActive = true, IsDelete = false },
                new Discount { Id = Guid.NewGuid(), CreaatedDate = DateTime.Now, CustomerType = Domain.Enums.CustomerType.OldCustomer, DiscountRatio = 5, IsActive = true, IsDelete = false }
              );
        }
    }
}

