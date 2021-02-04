using MicroserviceFramework.AspNetCore.FeatureManagement;
using MicroserviceFramework.AspNetCore.Mvc.ModelBinding;
using MicroserviceFramework.FeatureManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ISession = MicroserviceFramework.Application.ISession;

namespace MicroserviceFramework.AspNetCore
{
	public static class ServiceCollectionExtensions
	{
		public static MicroserviceFrameworkBuilder UseAspNetCore(this MicroserviceFrameworkBuilder builder)
		{
			builder.Services.AddHttpContextAccessor();
			builder.Services.TryAddScoped<ISession, HttpContextSession>();
			return builder;
		}

		public static void UseFeatureManagement(this MicroserviceFrameworkBuilder builder)
		{
			builder.Services.AddFunction<AspNetCoreFeatureFinder>();
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