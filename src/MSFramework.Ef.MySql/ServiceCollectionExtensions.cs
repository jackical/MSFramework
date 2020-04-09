using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace MSFramework.Ef.MySql
{
	public static class ServiceCollectionExtensions
	{
		public static EntityFrameworkBuilder AddMySql<TDbContext>(
			this EntityFrameworkBuilder builder, bool pooled = true) where TDbContext : DbContextBase
		{
			builder.Services.AddMySql<TDbContext>(pooled);
			return builder;
		}

		public static EntityFrameworkBuilder AddMySql<TDbContext1, TDbContext2>(
			this EntityFrameworkBuilder builder, bool pooled = true) where TDbContext1 : DbContextBase
			where TDbContext2 : DbContextBase
		{
			builder.Services.AddMySql<TDbContext1>(pooled);
			builder.Services.AddMySql<TDbContext2>(pooled);
			return builder;
		}

		public static EntityFrameworkBuilder AddMySql<TDbContext1, TDbContext2, TDbContext3>(
			this EntityFrameworkBuilder builder, bool pooled = true) where TDbContext1 : DbContextBase
			where TDbContext2 : DbContextBase
			where TDbContext3 : DbContextBase
		{
			builder.Services.AddMySql<TDbContext1>(pooled);
			builder.Services.AddMySql<TDbContext2>(pooled);
			builder.Services.AddMySql<TDbContext3>(pooled);

			return builder;
		}

		public static IServiceCollection AddMySql<TDbContext>(
			this IServiceCollection services, bool pooled = true) where TDbContext : DbContextBase
		{
			var action = new Action<DbContextOptionsBuilder>(x =>
			{
				var dbContextType = typeof(TDbContext);
				var entryAssemblyName = dbContextType.Assembly.GetName().Name;
				var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
				if (string.IsNullOrWhiteSpace(environment))
				{
					environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
				}

				var configurationBuilder = new ConfigurationBuilder();
				configurationBuilder.AddJsonFile("appsettings.json");
				if (!string.IsNullOrWhiteSpace(environment))
				{
					configurationBuilder.AddJsonFile($"appsettings.{environment}.json");
				}

				var configuration = configurationBuilder.Build();
				var store = EntityFrameworkOptionsStore.LoadFrom(configuration);
				var option = store.Get(dbContextType);

				if (option.DbContextType != dbContextType)
				{
					throw new ArgumentException("DbContextType is not correct");
				}

				// todo: config 
				x.EnableSensitiveDataLogging();
				x.UseMySql(option.ConnectionString, options =>
				{
					options.MigrationsAssembly(entryAssemblyName);
					options.CharSet(CharSet.Utf8Mb4);
				});
			});
			if (pooled)
			{
				services.AddDbContextPool<TDbContext>(action);
			}
			else
			{
				services.AddDbContext<TDbContext>(action);
			}

			return services;
		}
	}
}