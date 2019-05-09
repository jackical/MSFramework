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
				g.Property(user => user.ClientId);
				g.Property(user => user.ClientName).HasMaxLength(200);
				g.Property(user => user.ClientUserId);
				g.Property(user => user.ClientShortName).HasMaxLength(200);
				g.Property(user => user.LastName).HasMaxLength(50);
				g.Property(user => user.FirstName).HasMaxLength(50);
			});

			appointmentConfiguration.OwnsOne(o => o.Sale, builder =>
			{
				builder.Property(u => u.UserId);
				builder.Property(u => u.Email).HasMaxLength(200);
				builder.Property(u => u.LastName).HasMaxLength(100);
				builder.Property(u => u.FirstName).HasMaxLength(100);
				builder.Property(u => u.TeamName).HasMaxLength(200);
				builder.Property(u => u.GroupName).HasMaxLength(200);
			});
			
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