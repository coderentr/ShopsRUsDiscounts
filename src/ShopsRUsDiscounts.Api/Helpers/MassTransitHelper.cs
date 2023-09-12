using System;
using MassTransit;
using ShopsRUsDiscounts.Infrastructure.Cunsomers;
using ShopsRUsDiscounts.Infrastructure.MessageBroker;

namespace ShopsRUsDiscounts.Api.Helpers
{
	public static class MassTransitHelper
	{
        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<SyncCreateInvoiceCunsomer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(configuration.GetConnectionString("RabbitMQCon")), host => { });

                    cfg.ReceiveEndpoint(EventPublish.SyncInvoiceQueue, e =>
                    {
                        e.ConfigureConsumer<SyncCreateInvoiceCunsomer>(context);
                    });
                });
            });
            return services;
        }

    }
}

