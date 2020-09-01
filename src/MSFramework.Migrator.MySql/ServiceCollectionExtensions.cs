using System;
using MicroserviceFramework.Initializers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MicroserviceFramework.Migrator.MySql
{
	public static class ServiceCollectionExtensions
	{
		public static MicroserviceFrameworkBuilder UseMySqlMigrator(this MicroserviceFrameworkBuilder builder, Type type,
			string connectionString)
		{
			builder.Services.AddSingleton<Initializer>(provider => new MySqlMigrator(type, connectionString,
				provider.GetRequiredService<ILogger<MySqlMigrator>>()));
			return builder;
		}
	}
}