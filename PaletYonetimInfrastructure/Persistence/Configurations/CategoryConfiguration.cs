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
	public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
	{
		public void Configure(EntityTypeBuilder<CategoryEntity> builder)
		{
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

