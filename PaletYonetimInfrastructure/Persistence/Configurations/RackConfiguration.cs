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
	public class RackConfiguration : BaseConfiguration<RackEntity>
	{
		public override void Configure(EntityTypeBuilder<RackEntity> builder)
		{
			base.Configure(builder);
			// Primary Key
			builder.HasKey(e => e.RackID);

			// CorridorNumber alanı zorunlu ve aralık sınırı eklenebilir
			builder.Property(e => e.CorridorNumber)
				   .IsRequired();

			// Corridor alanı zorunlu
			builder.Property(e => e.Corridor)
				   .IsRequired()
				   .HasConversion<string>(); // Enum'u string olarak sakla

			// Floor alanı zorunlu ve aralık kontrolü
			builder.Property(e => e.Floor)
				   .IsRequired();

			// Row alanı zorunlu
			builder.Property(e => e.Row)
				   .IsRequired();

			// IsOccupied alanı zorunlu
			builder.Property(e => e.IsOccupied)
				   .IsRequired();

			// UsageType alanı zorunlu
			builder.Property(e => e.UsageType)
				   .IsRequired()
				   .HasConversion<string>(); // Enum'u string olarak sakla

			// Pallets ile ilişki (1-N)
			builder.HasMany(e => e.Pallets)
				   .WithOne(p => p.Rack)
				   .HasForeignKey(p => p.RackID)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
