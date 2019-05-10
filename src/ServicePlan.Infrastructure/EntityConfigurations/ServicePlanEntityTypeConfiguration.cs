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

			configuration.OwnsOne(o => o.Product, sa =>
			{
				//sa.HasKey("_id");
				sa.Property(p => p.ProductId);
				sa.Property(p => p.Name).HasMaxLength(200);
				sa.Property(p => p.Type);
				sa.OwnsMany(p => p.Subscriber, g =>
				{
					g.HasKey("_id");
					g.Property(user => user.ClientId);
					g.Property(user => user.ClientName).HasMaxLength(200);
					g.Property(user => user.ClientUserId);
					g.Property(user => user.ClientShortName).HasMaxLength(200);
					g.Property(user => user.LastName).HasMaxLength(50);
					g.Property(user => user.FirstName).HasMaxLength(50);
				});
			});
			
			configuration.OwnsOne(o => o.QcUser, builder =>
			{
				//builder.HasKey("_id");
				builder.Property(u => u.UserId);
				builder.Property(u => u.Email).HasMaxLength(200);
				builder.Property(u => u.LastName).HasMaxLength(100);
				builder.Property(u => u.FirstName).HasMaxLength(100);
				builder.Property(u => u.TeamName).HasMaxLength(200);
				builder.Property(u => u.GroupName).HasMaxLength(200);
			});
			
			configuration.OwnsOne(o => o.User, builder =>
			{
				//builder.HasKey("_id");
				builder.Property(u => u.UserId);
				builder.Property(u => u.Email).HasMaxLength(200);
				builder.Property(u => u.LastName).HasMaxLength(100);
				builder.Property(u => u.FirstName).HasMaxLength(100);
				builder.Property(u => u.TeamName).HasMaxLength(200);
				builder.Property(u => u.GroupName).HasMaxLength(200);
			});
			
			configuration.OwnsOne(o => o.Creator,builder =>
			{
				//builder.HasKey("_id");
				builder.Property(u => u.UserId);
				builder.Property(u => u.Email).HasMaxLength(200);
				builder.Property(u => u.LastName).HasMaxLength(100);
				builder.Property(u => u.FirstName).HasMaxLength(100);
				builder.Property(u => u.TeamName).HasMaxLength(200);
				builder.Property(u => u.GroupName).HasMaxLength(200);
			});
			
			configuration.OwnsOne(o => o.AuditUser, builder =>
			{
				//builder.HasKey("_id");
				builder.Property(u => u.UserId);
				builder.Property(u => u.Email).HasMaxLength(200);
				builder.Property(u => u.LastName).HasMaxLength(100);
				builder.Property(u => u.FirstName).HasMaxLength(100);
				builder.Property(u => u.TeamName).HasMaxLength(200);
				builder.Property(u => u.GroupName).HasMaxLength(200);
			});

			configuration.OwnsOne(o => o.RoadShow, builder =>
			{
				//builder.HasKey("_id");
				builder.Property(rs => rs.Address).HasMaxLength(500);
				builder.OwnsMany(rs => rs.ClientUsers, g =>
				{
					g.HasKey("_id");
					g.Property(user => user.ClientId);
					g.Property(user => user.ClientName).HasMaxLength(200);
					g.Property(user => user.ClientUserId);
					g.Property(user => user.ClientShortName).HasMaxLength(200);
					g.Property(user => user.LastName).HasMaxLength(50);
					g.Property(user => user.FirstName).HasMaxLength(50);
				});
			});

			configuration.OwnsOne(o => o.DataReport, builder =>
			{
				//builder.HasKey("_id");
				builder.Property(dr => dr.Abstract).IsRequired(false).HasMaxLength(2000);
				builder.Property(dr => dr.ReportTitle).IsRequired(false).HasMaxLength(200);
			});

			configuration.OwnsMany(o => o.AuditHistory, builder =>
			{
				builder.HasKey("_id");
				builder.Property(a => a.Result).HasMaxLength(300);
				builder.Property(a => a.Operation).HasMaxLength(100);
				builder.OwnsOne(a => a.User, g =>
				{
					//g.HasKey("_id");
					g.Property(u => u.Email).HasMaxLength(200);
					g.Property(u => u.LastName).HasMaxLength(100);
					g.Property(u => u.FirstName).HasMaxLength(100);
					g.Property(u => u.TeamName).HasMaxLength(100);
					g.Property(u => u.GroupName).HasMaxLength(100);
				});
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