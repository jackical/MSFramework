using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.EntityFrameworkCore;
using ServicePlan.Domain.AggregateRoot;

namespace ServicePlan.Infrastructure.EntityConfigurations
{
	public class ServicePlanEntityTypeConfiguration : EntityTypeConfigurationBase<Domain.AggregateRoot.ServicePlan>
	{
		public override Type DbContextType => typeof(ServicePlanContext);
		
		public override void Configure(EntityTypeBuilder<Domain.AggregateRoot.ServicePlan> configuration)
		{ 
			configuration.HasKey(o => o.Id);
			
			configuration.Property<string>("Name").IsRequired().HasMaxLength(200);
			
			configuration.Property<int>("PlanTypeId").IsRequired();
			
			configuration.Property<int>("PlanStateId").IsRequired();
			
			configuration.Property<int>("ValidationStateId").IsRequired();
			
			configuration.Property<int>("AuditStateId").IsRequired();
			
			configuration.Property<DateTime>("BeginTime").IsRequired();

			configuration.Property<DateTime>("EndTime").IsRequired();
			
			configuration.Property<bool>("Deleted").IsRequired().HasDefaultValue(false);

			configuration.Property(o => o.ProductId).HasMaxLength(50).IsRequired(false);
			
			configuration.Property(o => o.QcUser).HasMaxLength(50).IsRequired(false);
			
			configuration.Property(o => o.User).HasMaxLength(50).IsRequired();
			
			configuration.Property(o => o.Creator).HasMaxLength(50).IsRequired();
			
			configuration.Property(o => o.AuditUser).HasMaxLength(50).IsRequired(false);

			configuration.OwnsOne(o => o.RoadShow, builder =>
			{
				builder.Property(rs => rs.Address).HasMaxLength(500);
				builder.OwnsMany(rs => rs.ClientUsers, g =>
				{
					g.HasKey("_id");
				});
			});

			configuration.OwnsOne(o => o.DataReport, builder =>
			{
				builder.Property(dr => dr.Abstract).IsRequired(false).HasMaxLength(2000);
				builder.Property(dr => dr.ReportTitle).IsRequired(false).HasMaxLength(200);
			});

			configuration.OwnsMany(o => o.AuditHistory, builder =>
			{
				builder.HasKey("_id");
				builder.Property(a => a.Result).IsRequired().HasMaxLength(300);
				builder.Property(a => a.Operation).IsRequired().HasMaxLength(100);
				builder.Property(a => a.User).IsRequired().HasMaxLength(50);
			});

			//var roadShowNavigation = configuration.Metadata.FindNavigation("RoadShow");
			//roadShowNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			//var dataReportNavigation = configuration.Metadata.FindNavigation("DataReport");
			//dataReportNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			var attachmentsNavigation = configuration.Metadata.FindNavigation("Attachments");
			attachmentsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			var emailRecordsNavigation = configuration.Metadata.FindNavigation("EmailRecords");
			emailRecordsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

			//var auditHistoryNavigation = configuration.Metadata.FindNavigation("AuditHistories");
			//auditHistoryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			var serviceRecordNavigation = configuration.Metadata.FindNavigation("ServiceRecords");
			serviceRecordNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}