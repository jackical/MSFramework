using System;
using System.Threading.Tasks;

namespace MicroserviceFramework.Domain.Events
{
	public interface IEventDispatcher : IDisposable
	{
		bool Register<TEvent, TEventHandler>()
			where TEvent : Event
			where TEventHandler : IEventHandler<TEvent>;

		bool Register<TEvent>(Type handlerType)
			where TEvent : Event;

		bool Register(Type eventType, Type handlerType);

		Task DispatchAsync(IEvent @event);
	}
}