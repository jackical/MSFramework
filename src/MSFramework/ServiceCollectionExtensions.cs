using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MicroserviceFramework.Application;
using MicroserviceFramework.Audits;
using MicroserviceFramework.Domain;
using MicroserviceFramework.Domain.Events;
using MicroserviceFramework.Initializers;
using MicroserviceFramework.Reflection;
using MicroserviceFramework.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
// ReSharper disable InconsistentNaming

namespace MicroserviceFramework
{
	public static class ServiceCollectionExtensions
	{
		public static MicroserviceFrameworkBuilder UseEventDispatcher(this MicroserviceFrameworkBuilder builder)
		{
			var assemblies = AssemblyFinder.GetAllList();
			builder.UseEventDispatcher(assemblies.ToArray());
			return builder;
		}

		public static MicroserviceFrameworkBuilder UseCQRS(this MicroserviceFrameworkBuilder builder)
		{
			var assemblies = AssemblyFinder.GetAllList();
			builder.UseCQRS(assemblies.ToArray());
			return builder;
		}

		public static MicroserviceFrameworkBuilder UseCQRS(this MicroserviceFrameworkBuilder builder,
			params Type[] commandTypes)
		{
			var excludeAssembly = typeof(MicroserviceFrameworkBuilder).Assembly;
			var assemblies = commandTypes.Select(x => x.Assembly).ToList();

			if (!assemblies.Contains(excludeAssembly))
			{
				assemblies.Add(excludeAssembly);
			}

			builder.UseCQRS(assemblies.ToArray());
			return builder;
		}

		public static MicroserviceFrameworkBuilder UseEventDispatcher(this MicroserviceFrameworkBuilder builder, params Type[] eventTypes)
		{
			var excludeAssembly = typeof(MicroserviceFrameworkBuilder).Assembly;
			var assemblies = eventTypes.Select(x => x.Assembly).ToList();

			if (!assemblies.Contains(excludeAssembly))
			{
				assemblies.Add(excludeAssembly);
			}

			builder.UseEventDispatcher(assemblies.ToArray());
			return builder;
		}

		public static MicroserviceFrameworkBuilder UseEventDispatcher(this MicroserviceFrameworkBuilder builder,
			params Assembly[] assemblies)
		{
			builder.Services.AddEventDispatcher(assemblies);
			return builder;
		}
		
		public static MicroserviceFrameworkBuilder UseCQRS(this MicroserviceFrameworkBuilder builder,
			params Assembly[] assemblies)
		{
			builder.Services.AddCQRS(assemblies);
			return builder;
		}

		public static void AddMicroserviceFramework(this IServiceCollection services,
			Action<MicroserviceFrameworkBuilder> builderAction = null)
		{
			var builder = new MicroserviceFrameworkBuilder(services);
			builderAction?.Invoke(builder);
			
			builder.Services.TryAddScoped<IUnitOfWorkManager, DefaultUnitOfWorkManager>();

			// 如果你想换成消息队列，则重新注册一个对应的服务即可
			builder.Services.TryAddScoped<IAuditService, DefaultAuditService>();

			builder.UseInitializer();
		}

		public static MicroserviceFrameworkBuilder UseBaseX(this MicroserviceFrameworkBuilder builder,
			string path = "basex.txt")
		{
			string codes;
			if (!File.Exists(path))
			{
				codes = BaseX.GetRandomCodes();
				File.WriteAllText(path, codes);
			}
			else
			{
				codes = File.ReadAllLines(path).FirstOrDefault();
			}

			if (string.IsNullOrWhiteSpace(codes) || codes.Length < 34)
			{
				throw new ArgumentException("Codes show large than 34 char");
			}

			BaseX.Load(codes);
			return builder;
		}

		public static void UseMicroserviceFramework(this IServiceProvider applicationServices)
		{
			InitializeAsync(applicationServices).GetAwaiter().GetResult();
		}

		private static async Task InitializeAsync(IServiceProvider applicationServices)
		{
			using var scope = applicationServices.CreateScope();
			var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("Initializer");
			var initializers = scope.ServiceProvider.GetServices<Initializer>().OrderBy(x => x.Order).ToList();
			logger.LogInformation($"{string.Join(" -> ", initializers.Select(x => x.GetType().FullName))}");
			foreach (var initializer in initializers)
			{
				await initializer.InitializeAsync(scope.ServiceProvider);
			}
		}
	}
}