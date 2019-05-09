using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Infrastructure.EntityConfigurations
{
	public class EmailRecordEntityTypeConfiguration: EntityTypeConfigurationBase<EmailRecord>
	{
		public override Type DbContextType => typeof(ServicePlanContext);
		
		public override void Configure(EntityTypeBuilder<EmailRecord> configuration)
		{ 
			configuration.HasKey(o => o.Id);
			configuration.Ignore(o => o.ClientUser);
			configuration.Property<DateTime>("CreationTime").IsRequired();
			configuration.Property<bool?>("Success").IsRequired(false);
			configuration.Property<DateTime?>("ResponseTime").IsRequired(false);
		}
	}
}