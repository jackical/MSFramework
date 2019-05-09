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

			//appointmentConfiguration.HasMany(o => o.ClientUsers);

			//appointmentConfiguration.OwnsOne(o => o.Sale);

			//appointmentConfiguration.Ignore(o => o.ClientUsers);
			
			appointmentConfiguration.Ignore(o => o.Sale);

			appointmentConfiguration.Property<bool>("Booked").IsRequired();

			appointmentConfiguration.Property<DateTime?>("BookTime").IsRequired(false);

			appointmentConfiguration.Property<DateTime>("BeginTime").IsRequired();

			appointmentConfiguration.Property<DateTime>("EndTime").IsRequired();

			appointmentConfiguration.Property<string>("Location").IsRequired(false);

			appointmentConfiguration.Property<string>("Address").IsRequired(false);
			
			appointmentConfiguration.Property<string>("Description").IsRequired(false);
			
			appointmentConfiguration.Property<Guid?>("PlanId").IsRequired(false);
		}
	}
}