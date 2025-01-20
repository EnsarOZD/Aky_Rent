using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence.Configurations
{
	public class UserConfiguration : BaseConfiguration<UserEntity>
	{
		public override void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			base.Configure(builder);
			builder.HasKey(e => e.UserID);

			builder.Property(e => e.FirstName)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(e => e.LastName)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(e => e.Email)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(e => e.Password)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.HasOne(e => e.Role)
				   .WithMany(r => r.Users)
				   .HasForeignKey(e => e.RoleID)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
