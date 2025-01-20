using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence.Configurations
{
	public class RoleConfiguration : BaseConfiguration<RoleEntity>
	{
		public override void Configure(EntityTypeBuilder<RoleEntity> builder)
		{
			base.Configure(builder);
			builder.HasKey(e => e.RoleID);

			builder.Property(e => e.RoleName)
				   .IsRequired();
		}
	}
}
