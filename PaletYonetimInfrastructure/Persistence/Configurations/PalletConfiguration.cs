﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence.Configurations
{
	public class PalletConfiguration : BaseConfiguration<PalletEntity>
	{
		public override void Configure(EntityTypeBuilder<PalletEntity> builder)
		{
			base.Configure(builder);
			builder.HasKey(e => e.PalletID);

			builder.Property(e => e.Status)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(e => e.Barcode)
				   .HasMaxLength(50)
				   .IsRequired(false);

			builder.Property(e => e.QRCode)
				   .HasMaxLength(200)
				   .IsRequired(false);

			builder.HasOne(e => e.Rack)
				   .WithMany(r => r.Pallets)
				   .HasForeignKey(e => e.RackID)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(e => e.Customer)
				   .WithMany(c => c.Pallets)
				   .HasForeignKey(e => e.CustomerID)
				   .OnDelete(DeleteBehavior.SetNull);
		}
	}
}
