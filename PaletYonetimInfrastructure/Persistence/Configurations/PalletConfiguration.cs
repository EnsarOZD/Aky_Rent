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
	public class PalletConfiguration : IEntityTypeConfiguration<PalletEntity>
	{
		public void Configure(EntityTypeBuilder<PalletEntity> builder)
		{
			builder.HasKey(e => e.PalletID);

			builder.Property(e => e.Status)
				   .IsRequired()
				   .HasMaxLength(50);

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
