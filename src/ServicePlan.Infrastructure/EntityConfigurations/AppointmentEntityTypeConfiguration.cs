using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Infrastructure.EntityConfigurations
{
	public class AppointmentEntityTypeConfiguration : EntityTypeConfigurationBase<Appointment>
	{
		public override Type DbContextType => typeof(ServicePlanContext);
		
		public override void Configure(EntityTypeBuilder<Appointment> appointmentConfiguration)
		{ 
			appointmentConfiguration.HasKey(o => o.Id);

			appointmentConfiguration.OwnsMany(o => o.ClientUsers, g =>
			{
				g.HasKey("_id");
			});

			appointmentConfiguration.Property(o => o.Sale).IsRequired(false).HasMaxLength(50);
			
			appointmentConfiguration.Property(o => o.Booked).IsRequired();

			appointmentConfiguration.Property<DateTime?>("BookTime").IsRequired(false);

			appointmentConfiguration.Property<DateTime>("BeginTime").IsRequired();

			appointmentConfiguration.Property<DateTime>("EndTime").IsRequired();

			appointmentConfiguration.Property<string>("Location").IsRequired(false).HasMaxLength(200);

			appointmentConfiguration.Property<string>("Address").IsRequired(false).HasMaxLength(300);
			
			appointmentConfiguration.Property<string>("Description").IsRequired(false).HasMaxLength(500);
			
			appointmentConfiguration.Property<Guid?>("PlanId").IsRequired(false);
		}
	}
}