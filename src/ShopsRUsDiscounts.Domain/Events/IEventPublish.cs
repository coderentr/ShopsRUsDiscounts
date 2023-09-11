using System;
namespace ShopsRUsDiscounts.Domain.Events
{
	public interface IEventPublish
	{
        Task Publish<T>(T @event);
    }
}

