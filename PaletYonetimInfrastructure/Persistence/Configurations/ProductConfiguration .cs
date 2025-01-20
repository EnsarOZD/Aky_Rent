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
	public class ProductConfiguration : BaseConfiguration<ProductEntity>
	{
		public override void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			base.Configure(builder);
			builder.HasKey(e => e.ProductID);

			builder.Property(e => e.Name)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(e => e.Barcode)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(e => e.Unit)
				   .HasMaxLength(20)
				   .IsRequired(true);

			builder.Property(e => e.CustomerStockCode)
				   .HasMaxLength(50)
				   .IsRequired(false);

			builder.HasOne(e => e.Category)
				   .WithMany(c => c.Products)
				   .HasForeignKey(e => e.CategoryID)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
