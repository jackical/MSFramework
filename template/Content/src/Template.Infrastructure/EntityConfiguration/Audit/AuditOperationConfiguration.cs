using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFramework.Audit;
using MSFramework.Ef;
using MSFramework.Ef.Extensions;

namespace Template.Infrastructure.EntityConfiguration.Audit
{
    public class AuditOperationConfiguration
        : EntityTypeConfigurationBase<AuditOperation, AppDbContext>
    {
        public override void Configure(EntityTypeBuilder<AuditOperation> builder)
        {
            base.Configure(builder);

            builder.ToTable("audit_operation");

            builder.HasMany(x => x.Entities).WithOne().HasForeignKey("audit_operation_id");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Ip).HasColumnName("ip").HasMaxLength(255);
            builder.Property(x => x.Path).HasColumnName("path").HasMaxLength(255);
            builder.Property(x => x.ApplicationName).HasColumnName("application_name").HasMaxLength(255);
            builder.Property(x => x.UserAgent).HasColumnName("user_agent").HasMaxLength(500);
            builder.Property(x => x.Elapsed).HasColumnName("elapsed");
            builder.Property(x => x.EndTime).HasColumnName("end_time").UseUnixTimeSeconds();
            builder.ConfigureCreationAudited();

            builder.HasIndex(x => x.CreationTime);
            builder.HasIndex(x => x.CreationUserId);
            builder.HasIndex(x => x.EndTime);
        }
    }
}