using System;
using ShopsRUsDiscounts.Domain.Events;
using ShopsRUsDiscounts.Domain.Interfaces;
using ShopsRUsDiscounts.Infrastructure.MessageBroker;
using ShopsRUsDiscounts.Infrastructure.Repositories;

namespace ShopsRUsDiscounts.Api.Helpers
{
	public static class ServiceCollectionHelper
	{
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IEventPublish, EventPublish>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            return services;
        }
    }
}

