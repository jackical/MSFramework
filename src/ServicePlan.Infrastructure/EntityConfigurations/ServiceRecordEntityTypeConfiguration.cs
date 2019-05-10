using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Infrastructure.EntityConfigurations
{
	public class ServiceRecordEntityTypeConfiguration : EntityTypeConfigurationBase<ServiceRecord>
	{
		public override Type DbContextType => typeof(ServicePlanContext);
		
		public override void Configure(EntityTypeBuilder<ServiceRecord> configuration)
		{ 
			configuration.HasKey(o => o.Id);

			configuration.OwnsMany(o => o.ClientUsers, g =>
			{
				g.HasKey("_id");
				g.Property(user => user.ClientId);
				g.Property(user => user.ClientName).HasMaxLength(200);
				g.Property(user => user.ClientUserId);
				g.Property(user => user.ClientShortName).HasMaxLength(200);
				g.Property(user => user.LastName).HasMaxLength(100);
				g.Property(user => user.FirstName).HasMaxLength(100);
			});

			configuration.Property<DateTime>("ServiceTime").IsRequired();
			configuration.Property<int>("PlanTypeId").IsRequired();
			configuration.Property<string>("Subject").IsRequired(false).HasMaxLength(200);
			configuration.Property<string>("IndustryId").IsRequired(false).HasMaxLength(50);
			configuration.Property<string>("ClientFocusKeyPoint").IsRequired(false).HasMaxLength(500);
			configuration.Property<bool?>("Continue").IsRequired(false);
			configuration.Property<string>("ModificationRequirement").IsRequired(false).HasMaxLength(1000);
			configuration.Property<string>("NewRequirement").IsRequired(false).HasMaxLength(1000);
			configuration.Property<int?>("Score").IsRequired(false);
			configuration.Property<string>("Feedback").IsRequired(false).HasMaxLength(1000);
		}
	}
}