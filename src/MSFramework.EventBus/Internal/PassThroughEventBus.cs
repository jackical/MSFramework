using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MSFramework.EventBus.Internal
{
	public class PassThroughEventBus : IEventBus
	{
		private readonly IEventBusStore _store;
		private readonly ILogger _logger;
		private readonly IServiceScopeFactory _scopeFactory;

		public PassThroughEventBus(ILogger<PassThroughEventBus> logger, IServiceScopeFactory scopeFactory,
			IEventBusStore store)
		{
			_store = store;
			_logger = logger;
			_scopeFactory = scopeFactory;
		}

		public async Task PublishAsync(IEvent @event)
		{
			var eventName = _store.GetEventKey(@event.GetType());
			if (_store.ContainSubscription(eventName))
			{
				using (var scope = _scopeFactory.CreateScope())
				{
					var subscriptions = _store.GetHandlers(eventName);
					foreach (var subscription in subscriptions)
					{
						if (subscription.IsDynamic)
						{
							var handler =
								scope.ServiceProvider.GetService(subscription.HandlerType) as IDynamicEventHandler;
							if (handler == null) continue;
							await handler.Handle(@event);
						}
						else
						{
							var handler = scope.ServiceProvider.GetService(subscription.HandlerType);
							if (handler == null) continue;

							var concreteType = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
							// ReSharper disable once PossibleNullReferenceException
							await (Task) concreteType.GetMethod("Handle").Invoke(handler, new object[] {@event});
						}
					}
				}
			}
		}

		public void Subscribe<T, TH>() where T : class, IEvent where TH : IEventHandler<T>
		{
			var eventName = _store.GetEventKey<T>();

			_logger.LogInformation("Subscribing to event {EventName} with {EventHandler}", eventName,
				typeof(TH).GetEventName());

			_store.AddSubscription<T, TH>();
		}

		public void Subscribe<TH>(string eventName) where TH : IDynamicEventHandler
		{
			_logger.LogInformation("Subscribing to dynamic event {EventName} with {EventHandler}", eventName,
				typeof(TH).GetEventName());
			_store.AddSubscription<TH>(eventName);
		}

		public void Unsubscribe<TH>(string eventName) where TH : IDynamicEventHandler
		{
			_store.RemoveSubscription<TH>(eventName);
		}

		public void Unsubscribe<T, TH>() where T : class, IEvent where TH : IEventHandler<T>
		{
			var eventName = _store.GetEventKey<T>();

			_logger.LogInformation("Unsubscribing from event {EventName}", eventName);

			_store.RemoveSubscription<T, TH>();
		}
	}
}