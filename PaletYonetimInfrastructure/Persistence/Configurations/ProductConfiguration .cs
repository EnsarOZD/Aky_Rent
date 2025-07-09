using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;
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

			builder.Property(e => e.QRCode)
				   .HasMaxLength(200)
				   .IsRequired(false);

			builder.Property(e => e.Unit)
				   .HasConversion<string>()
				   .IsRequired();

			builder.Property(e => e.CustomerStockCode)
				   .HasMaxLength(50)
				   .IsRequired(false);

			// Yeni alanlar için konfigürasyon
			builder.Property(e => e.SKU)
				   .HasMaxLength(50)
				   .IsRequired(false);

			builder.Property(e => e.Weight)
				   .HasPrecision(10, 2)
				   .IsRequired();

			builder.Property(e => e.Length)
				   .HasPrecision(10, 2)
				   .IsRequired(false);

			builder.Property(e => e.Width)
				   .HasPrecision(10, 2)
				   .IsRequired(false);

			builder.Property(e => e.Height)
				   .HasPrecision(10, 2)
				   .IsRequired(false);

			builder.Property(e => e.MinimumStockLevel)
				   .IsRequired()
				   .HasDefaultValue(0);

			builder.Property(e => e.MaximumStockLevel)
				   .IsRequired()
				   .HasDefaultValue(1000);

			builder.Property(e => e.ReorderPoint)
				   .IsRequired()
				   .HasDefaultValue(10);

			builder.Property(e => e.LotNumber)
				   .HasMaxLength(50)
				   .IsRequired(false);

			builder.Property(e => e.SerialNumber)
				   .HasMaxLength(50)
				   .IsRequired(false);

			builder.Property(e => e.IsHazardous)
				   .IsRequired()
				   .HasDefaultValue(false);

			builder.Property(e => e.RequiresColdStorage)
				   .IsRequired()
				   .HasDefaultValue(false);

			builder.Property(e => e.IsActive)
				   .IsRequired()
				   .HasDefaultValue(true);

			builder.HasOne(e => e.Category)
				   .WithMany(c => c.Products)
				   .HasForeignKey(e => e.CategoryID)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
