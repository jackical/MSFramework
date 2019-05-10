using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Infrastructure.EntityConfigurations
{
	public class AttachmentEntityTypeConfiguration : EntityTypeConfigurationBase<Attachment>
	{
		public override Type DbContextType => typeof(ServicePlanContext);

		public override void Configure(EntityTypeBuilder<Attachment> configuration)
		{
			configuration.HasKey(o => o.Id);
			configuration.Property<AttachmentType>("Type").IsRequired();
			configuration.Property<string>("Name").IsRequired().HasMaxLength(100);
			configuration.Property<string>("Path").IsRequired().HasMaxLength(300);
			configuration.Property<DateTime>("Creation").IsRequired();
		}
	}
}