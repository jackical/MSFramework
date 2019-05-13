using Microsoft.Extensions.DependencyInjection;
using MSFramework;
using MSFramework.EventBus;

namespace ServicePlan.Application
{
	public static class ServiceCollectionExtensions
	{
		public static MSFrameworkBuilder AddServicePlanApplication(this MSFrameworkBuilder builder)
		{			
			return builder;
		}
	}
}