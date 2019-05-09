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
			configuration.OwnsOne(o => o.ClientUser, g =>
			{
				g.Property(user => user.ClientId);
				g.Property(user => user.ClientName).HasMaxLength(200);
				g.Property(user => user.ClientUserId);
				g.Property(user => user.ClientShortName).HasMaxLength(200);
				g.Property(user => user.LastName).HasMaxLength(100);
				g.Property(user => user.FirstName).HasMaxLength(100);
			});
			configuration.Property<DateTime>("CreationTime").IsRequired();
			configuration.Property<bool?>("Success").IsRequired(false);
			configuration.Property<DateTime?>("ResponseTime").IsRequired(false);
		}
	}
}