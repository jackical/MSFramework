using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSFramework.EntityFrameworkCore;
using MSFramework.EventBus;

namespace ServicePlan.Infrastructure
{
	public class ServicePlanContext : DbContextBase
	{
		public ServicePlanContext(DbContextOptions options, IEntityConfigurationTypeFinder typeFinder,
			IEventBus eventBus,
			ILoggerFactory loggerFactory) : base(options, typeFinder, eventBus,
			loggerFactory)
		{
		}
	}
}