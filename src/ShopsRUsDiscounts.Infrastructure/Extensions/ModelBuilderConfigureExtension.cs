using System;
using Microsoft.EntityFrameworkCore;
using ShopsRUsDiscounts.Domain.Entities;

namespace ShopsRUsDiscounts.Infrastructure.Extensions
{
    public static class ModelBuilderConfigureExtension
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>()
            .HasIndex(c => c.CustomerType)
            .IsUnique();
        }
    }
}

