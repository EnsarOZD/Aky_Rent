using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletYonetimDomain.Entities;

namespace PaletYonetimInfrastructure.Persistence.Configurations
{
    public class AuditLogConfiguration : BaseConfiguration<AuditLogEntity>
    {
        public override void Configure(EntityTypeBuilder<AuditLogEntity> builder)
        {
            base.Configure(builder);
            builder.HasKey(e => e.AuditLogID);

            builder.Property(e => e.UserID)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.UserName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Action)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.EntityName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.EntityID)
                   .IsRequired();

            builder.Property(e => e.OldValues)
                   .HasMaxLength(4000)
                   .IsRequired(false);

            builder.Property(e => e.NewValues)
                   .HasMaxLength(4000)
                   .IsRequired(false);

            builder.Property(e => e.IPAddress)
                   .HasMaxLength(45)
                   .IsRequired(false);

            builder.Property(e => e.UserAgent)
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.Property(e => e.Description)
                   .HasMaxLength(1000)
                   .IsRequired(false);

            builder.Property(e => e.IsSuccessful)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(e => e.ErrorMessage)
                   .HasMaxLength(1000)
                   .IsRequired(false);

            // İndeksler
            builder.HasIndex(e => e.EntityName);
            builder.HasIndex(e => e.EntityID);
            builder.HasIndex(e => e.UserID);
            builder.HasIndex(e => e.CreatedTime);
            builder.HasIndex(e => new { e.EntityName, e.EntityID });
            builder.HasIndex(e => new { e.UserID, e.CreatedTime });
        }
    }
} 