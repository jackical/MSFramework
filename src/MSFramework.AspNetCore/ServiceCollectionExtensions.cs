using MicroserviceFramework.AspNetCore.Function;
using MicroserviceFramework.AspNetCore.Infrastructure;
using MicroserviceFramework.Function;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ISession = MicroserviceFramework.Application.ISession;

namespace MicroserviceFramework.AspNetCore
{
	public static class ServiceCollectionExtensions
	{
		public static MicroserviceFrameworkBuilder UseAspNetCore(this MicroserviceFrameworkBuilder builder,
			bool enableFunction = true)
		{
			if (enableFunction)
			{
				builder.Services.TryAddSingleton<IFunctionDefineFinder, AspNetCoreFunctionFinder>();
			}

			builder.Services.AddHttpContextAccessor();
			builder.Services.AddSingleton<IActionResultTypeMapper, ActionResultTypeMapper>();
			builder.Services.TryAddScoped<ISession, HttpContextSession>();
			return builder;
		}

		public static void UseMicroserviceFramework(this IApplicationBuilder builder)
		{
			builder.ApplicationServices.UseMicroserviceFramework();
		}

		public static IMvcBuilder ConfigureInvalidModelStateResponse(this IMvcBuilder builder)
		{
			builder.ConfigureApiBehaviorOptions(x =>
			{
				x.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.Instance;
			});
			return builder;
		}
	}
}