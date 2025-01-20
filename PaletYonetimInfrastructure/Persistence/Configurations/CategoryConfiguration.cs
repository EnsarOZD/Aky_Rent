using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence.Configurations
{
	public class CategoryConfiguration : BaseConfiguration<CategoryEntity>
	{
		public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
		{
			base.Configure(builder);
			builder.HasKey(e => e.CategoryID);

			builder.Property(e => e.CategoryName)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(e => e.Description)
				   .HasMaxLength(500)
				   .IsRequired(false);
		}
	}
}

