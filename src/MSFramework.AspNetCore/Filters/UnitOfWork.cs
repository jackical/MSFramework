using System.Collections.Concurrent;
using System.Threading.Tasks;
using MicroserviceFramework.AspNetCore.Extensions;
using MicroserviceFramework.Domain;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MicroserviceFramework.AspNetCore.Filters
{
	public class UnitOfWork : ActionFilterAttribute
	{
		private readonly ILogger _logger;
		private static readonly ConcurrentDictionary<string, object> MethodDict;

		static UnitOfWork()
		{
			MethodDict = new ConcurrentDictionary<string, object>();
			MethodDict.TryAdd("POST", null);
			MethodDict.TryAdd("DELETE", null);
			MethodDict.TryAdd("PATCH", null);
			MethodDict.TryAdd("PUT", null);
		}

		public UnitOfWork(ILogger<UnitOfWork> logger)
		{
			_logger = logger;
			Order = FilterOrders.UnitOfWork;
		}

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			await base.OnActionExecutionAsync(context, next);

			if (context.HasAttribute<IgnoreUnitOfWork>())
			{
				return;
			}

			if (MethodDict.ContainsKey(context.HttpContext.Request.Method))
			{
				var uowManager = context.HttpContext.RequestServices.GetService<UnitOfWorkManager>();
				if (uowManager != null)
				{
					await uowManager.CommitAsync();
				}

				_logger.LogDebug("Executed unit of work filter");
			}
		}
	}
}