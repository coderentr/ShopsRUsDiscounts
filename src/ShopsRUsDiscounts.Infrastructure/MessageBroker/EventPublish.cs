using System;
using MassTransit;
using ShopsRUsDiscounts.Domain.Events;

namespace ShopsRUsDiscounts.Infrastructure.MessageBroker
{
    public class EventPublish : IEventPublish
    {
        public const string SyncInvoiceQueue = "sync-invoice-queue";
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public EventPublish(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Publish<T>(T @event)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{SyncInvoiceQueue}"));

            await sendEndpoint.Send(@event);
        }
    }
}

