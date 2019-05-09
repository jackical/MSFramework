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
			roadShowConfiguration.OwnsOne(o => o.User,builder =>
			{
				builder.Property(u => u.UserId);
				builder.Property(u => u.Email).HasMaxLength(200);
				builder.Property(u => u.LastName).HasMaxLength(100);
				builder.Property(u => u.FirstName).HasMaxLength(100);
				builder.Property(u => u.TeamName).HasMaxLength(200);
				builder.Property(u => u.GroupName).HasMaxLength(200);
			});

			roadShowConfiguration.Property<DateTime>("BeginTime").IsRequired();
			roadShowConfiguration.Property<DateTime>("EndTime").IsRequired();
			roadShowConfiguration.Property<string>("KeyIdeaAndTopic").IsRequired(false).HasMaxLength(1000);

			var navigation = roadShowConfiguration.Metadata.FindNavigation(nameof(RoadShowWeekScheduler.Appointments));
            
			// DDD Patterns comment:
			//Set as field (New since EF 1.1) to access the OrderItem collection property through its field
			navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}