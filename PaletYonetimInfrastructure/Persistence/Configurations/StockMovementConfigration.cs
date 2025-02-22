﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletYonetimDomain.Entities;
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
		}
	}
}
