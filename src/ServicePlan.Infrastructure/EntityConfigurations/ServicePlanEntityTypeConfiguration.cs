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

			//configuration.OwnsOne(o => o.Product, sa =>
			//{
			//	sa.Property(p => p.ProductId);
			//	sa.Property(p => p.Name).HasColumnName("ProductName").HasMaxLength(200);
			//	sa.Property<int>("ProductTypeId");
			//	sa.Ignore(p => p.Type);
			//	sa.OwnsMany(p => p.Subscriber, g =>
			//	{
			//		g.Property<Guid>("Id");
			//		g.Property(user => user.ClientId);
			//		g.Property(user => user.ClientName).HasMaxLength(200);
			//		g.Property(user => user.ClientUserId);
			//		g.Property(user => user.ClientShortName).HasMaxLength(200);
			//		g.Property(user => user.LastName).HasMaxLength(50);
			//		g.Property(user => user.FirstName).HasMaxLength(50);
			//	});
			//});
			
			configuration.OwnsOne(o => o.QcUser, builder =>
			{
				builder.Property(u => u.UserId).HasColumnName("QcUserId");
				builder.Property(u => u.Email).HasColumnName("QcUserEmail").HasMaxLength(200);
				builder.Property(u => u.LastName).HasColumnName("QcUserLastName").HasMaxLength(200);
				builder.Property(u => u.FirstName).HasColumnName("QcUserFirstName").HasMaxLength(200);
				builder.Property(u => u.TeamName).HasColumnName("QcUserTeamName").HasMaxLength(200);
				builder.Property(u => u.GroupName).HasColumnName("QcUserGroupName").HasMaxLength(200);
			});
			
			configuration.OwnsOne(o => o.User, builder =>
			{
				builder.Property(u => u.UserId).HasColumnName("UserId");
				builder.Property(u => u.Email).HasColumnName("UserEmail").HasMaxLength(200);
				builder.Property(u => u.LastName).HasColumnName("UserLastName").HasMaxLength(200);
				builder.Property(u => u.FirstName).HasColumnName("UserFirstName").HasMaxLength(200);
				builder.Property(u => u.TeamName).HasColumnName("UserTeamName").HasMaxLength(200);
				builder.Property(u => u.GroupName).HasColumnName("UserGroupName").HasMaxLength(200);
			});
			
			configuration.OwnsOne(o => o.Creator,builder =>
			{
				builder.Property(u => u.UserId).HasColumnName("CreatorUserId");
				builder.Property(u => u.Email).HasColumnName("CreatorUserEmail").HasMaxLength(200);
				builder.Property(u => u.LastName).HasColumnName("CreatorUserLastName").HasMaxLength(200);
				builder.Property(u => u.FirstName).HasColumnName("CreatorUserFirstName").HasMaxLength(200);
				builder.Property(u => u.TeamName).HasColumnName("CreatorUserTeamName").HasMaxLength(200);
				builder.Property(u => u.GroupName).HasColumnName("CreatorUserGroupName").HasMaxLength(200);
			});
			
			configuration.OwnsOne(o => o.AuditUser, builder =>
			{
				builder.Property(u => u.UserId).HasColumnName("AuditUserId");
				builder.Property(u => u.Email).HasColumnName("AuditUserEmail").HasMaxLength(200);
				builder.Property(u => u.LastName).HasColumnName("AuditUserLastName").HasMaxLength(200);
				builder.Property(u => u.FirstName).HasColumnName("AuditUserFirstName").HasMaxLength(200);
				builder.Property(u => u.TeamName).HasColumnName("AuditUserTeamName").HasMaxLength(200);
				builder.Property(u => u.GroupName).HasColumnName("AuditUserGroupName").HasMaxLength(200);
			});

			configuration.Ignore(o => o.RoadShow);
			
			//configuration.OwnsOne(o => o.RoadShow, builder =>
			//{
			//	//builder.HasKey("_id");
			//	builder.Property(rs => rs.Address).HasMaxLength(500);
			//	builder.Ignore(rs => rs.ClientUsers);
			//	//builder.OwnsMany(rs => rs.ClientUsers, g =>
			//	//{
			//	//	g.HasKey("Id");
			//	//	g.Property(user => user.ClientId);
			//	//	g.Property(user => user.ClientName).HasMaxLength(200);
			//	//	g.Property(user => user.ClientUserId);
			//	//	g.Property(user => user.ClientShortName).HasMaxLength(200);
			//	//	g.Property(user => user.LastName).HasMaxLength(50);
			//	//	g.Property(user => user.FirstName).HasMaxLength(50);
			//	//});
			//});

			configuration.OwnsOne(o => o.DataReport, builder =>
			{
				builder.Property(dr => dr.Abstract);
				builder.Property(dr => dr.ReportTitle);
			});

			configuration.Ignore(o => o.AuditHistory);
			
			//configuration.Ignore(o => o.Product.Type);
			
			//configuration.HasMany(o => o.AuditHistory);

			//configuration.HasMany(o => o.Attachments);

			//configuration.HasMany(o => o.EmailRecords);

			//configuration.HasMany(o => o.AuditHistories);

			//configuration.HasMany(o => o.ServiceRecords);
				
			configuration.Property<string>("Name").IsRequired().HasMaxLength(200);
			
			//configuration.Property<string>("AuditHistory").IsRequired();
			
			configuration.Property<int>("PlanTypeId").IsRequired();
			
			configuration.Property<int>("PlanStateId").IsRequired();
			
			configuration.Property<int>("ValidationStateId").IsRequired();
			
			configuration.Property<int>("AuditStateId").IsRequired();
			
			configuration.Property<DateTime>("BeginTime").IsRequired();

			configuration.Property<DateTime>("EndTime").IsRequired();
			
			configuration.Property<bool>("Deleted").IsRequired().HasDefaultValue(false);
			
			//var roadShowNavigation = configuration.Metadata.FindNavigation("RoadShow");
			//roadShowNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			//var dataReportNavigation = configuration.Metadata.FindNavigation("DataReport");
			//dataReportNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			//var attachmentsNavigation = configuration.Metadata.FindNavigation("Attachments");
			//attachmentsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			//var emailRecordsNavigation = configuration.Metadata.FindNavigation("EmailRecords");
			//emailRecordsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

			//var auditHistoryNavigation = configuration.Metadata.FindNavigation("AuditHistories");
			//auditHistoryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			//var serviceRecordNavigation = configuration.Metadata.FindNavigation("ServiceRecords");
			//serviceRecordNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}