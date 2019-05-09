using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSFramework.EntityFrameworkCore;
using MSFramework.EntityFrameworkCore.SqlServer;

namespace ServicePlan.Infrastructure
{
	public class DesignTimeDbContextFactory: DesignTimeDbContextFactoryBase<ServicePlanContext>
	{
		protected override IConfiguration GetConfiguration()
		{
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
			Console.WriteLine("Config: " + path);
			var configuration =
				new ConfigurationBuilder().AddJsonFile(path, true, true).Build();
			return configuration;
		}

		protected override void Configure(IServiceCollection services)
		{
			services.AddSqlServerDbContextOptionsBuilderCreator();
		}
	}
}