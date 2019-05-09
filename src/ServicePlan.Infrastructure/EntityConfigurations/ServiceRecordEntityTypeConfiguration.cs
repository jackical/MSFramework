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

			//configuration.OwnsMany(o => o.ClientUsers, g =>
			//{
			//	g.HasKey(a => a.Id);
			//	g.Property(user => user.ClientId);
			//	g.Property(user => user.ClientName).HasMaxLength(200);
			//	g.Property(user => user.ClientUserId);
			//	g.Property(user => user.ClientShortName).HasMaxLength(200);
			//	g.Property(user => user.LastName).HasMaxLength(50);
			//	g.Property(user => user.FirstName).HasMaxLength(50);
			//});

			configuration.Ignore(o => o.ClientUsers);

			configuration.Property<DateTime>("ServiceTime").IsRequired();
			configuration.Property<int>("PlanTypeId").IsRequired();
			configuration.Property<string>("Subject").IsRequired(false);
			configuration.Property<string>("IndustryId").IsRequired(false);
			configuration.Property<string>("ClientFocusKeyPoint").IsRequired(false);
			configuration.Property<bool?>("Continue").IsRequired(false);
			configuration.Property<string>("ModificationRequirement").IsRequired(false);
			configuration.Property<string>("NewRequirement").IsRequired(false);
			configuration.Property<int?>("Score").IsRequired(false);
			configuration.Property<string>("Feedback").IsRequired(false);
		}
	}
}