using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence.Configurations
{
	public class StockMovementConfigration : BaseConfiguration<StockMovementEntity>
	{
		public override void Configure(EntityTypeBuilder<StockMovementEntity> builder)
		{
			base.Configure(builder);
			builder.HasKey(e => e.StockMovementID);

			builder.Property(e => e.Note)
				   .HasMaxLength(500)
				   .IsRequired(false);

			builder.Property(e => e.StockBalanceAfter)
				   .IsRequired();

			// Yeni alanlar için konfigürasyon
			builder.Property(e => e.MovementType)
				   .HasConversion<string>()
				   .IsRequired();

			builder.Property(e => e.MovementReason)
				   .HasConversion<string>()
				   .IsRequired();

			builder.Property(e => e.ApprovedBy)
				   .HasMaxLength(100)
				   .IsRequired(false);

			builder.Property(e => e.ScannedBarcode)
				   .HasMaxLength(50)
				   .IsRequired(false);

			builder.Property(e => e.ScannedQRCode)
				   .HasMaxLength(200)
				   .IsRequired(false);

			builder.Property(e => e.ReferenceNumber)
				   .HasMaxLength(100)
				   .IsRequired(false);

			// İlişkiler
			builder.HasOne(e => e.Pallet)
				   .WithMany(p => p.StockMovements)
				   .HasForeignKey(e => e.PalletID)
				   .OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(e => e.Transaction)
				   .WithMany(t => t.StockMovements)
				   .HasForeignKey(e => e.TransactionID)
				   .OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(e => e.Product)
				   .WithMany(p => p.StockMovements)
				   .HasForeignKey(e => e.ProductID)
				   .OnDelete(DeleteBehavior.NoAction);

			// Yeni konum ilişkileri
			builder.HasOne(e => e.FromLocation)
				   .WithMany()
				   .HasForeignKey(e => e.FromLocationID)
				   .OnDelete(DeleteBehavior.NoAction)
				   .IsRequired(false);

			builder.HasOne(e => e.ToLocation)
				   .WithMany()
				   .HasForeignKey(e => e.ToLocationID)
				   .OnDelete(DeleteBehavior.NoAction)
				   .IsRequired(false);
		}
	}
}
