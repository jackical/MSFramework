using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Infrastructure.EntityConfigurations
{
	
	public class RoadShowWeekSchedulerEntityConfiguration : EntityTypeConfigurationBase<RoadShowWeekScheduler>
	{
		public override Type DbContextType => typeof(ServicePlanContext);
		
		public override void Configure(EntityTypeBuilder<RoadShowWeekScheduler> roadShowConfiguration)
		{ 
			roadShowConfiguration.HasKey(o => o.Id);

			//Address value object persisted as owned entity type supported since EF Core 2.0
			roadShowConfiguration.Ignore(o => o.User).Ignore(o => o.Appointments);

			roadShowConfiguration.Property<DateTime>("BeginTime").IsRequired();
			roadShowConfiguration.Property<DateTime>("EndTime").IsRequired();
			roadShowConfiguration.Property<string>("KeyIdeaAndTopic").IsRequired(false);

			//var navigation = roadShowConfiguration.Metadata.FindNavigation(nameof(RoadShowWeekScheduler.Appointments));
            
			// DDD Patterns comment:
			//Set as field (New since EF 1.1) to access the OrderItem collection property through its field
			//navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}