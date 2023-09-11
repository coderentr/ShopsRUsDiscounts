using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace ShopsRUsDiscounts.Infrastructure.Context
{
   public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopsRUsDiscountsDBContext>
   {
       public ShopsRUsDiscountsDBContext CreateDbContext(string[] args)
       {
           var builder = new DbContextOptionsBuilder<ShopsRUsDiscountsDBContext>();
           var connectionString = "Server=localhost ;Database=ShopRUsDiscountDB;User ID=sa;Password=Qwer?1234;TrustServerCertificate=True;Encrypt=True;";
           builder.UseSqlServer(connectionString);
           return new ShopsRUsDiscountsDBContext(builder.Options);
       }
   }
}

