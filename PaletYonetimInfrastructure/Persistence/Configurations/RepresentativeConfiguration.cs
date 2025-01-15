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
	public class RepresentativeConfiguration : IEntityTypeConfiguration<RepresentativeEntity>
	{
		public void Configure(EntityTypeBuilder<RepresentativeEntity> builder)
		{
			// Primary Key
			builder.HasKey(e => e.RepresentativeID);

			// CustomerID alanı zorunlu
			builder.Property(e => e.CustomerID)
				   .IsRequired();

			// Name alanı zorunlu ve maksimum 100 karakter
			builder.Property(e => e.Name)
				   .IsRequired()
				   .HasMaxLength(100);

			// Phone alanı maksimum 20 karakter
			builder.Property(e => e.Phone)
				   .HasMaxLength(20)
				   .IsRequired(false); // Telefon numarası opsiyonel

			// Email alanı maksimum 100 karakter
			builder.Property(e => e.Email)
				   .HasMaxLength(100)
				   .IsRequired(false); // E-posta opsiyonel

			// IsPrimary alanı zorunlu
			builder.Property(e => e.IsPrimary)
				   .IsRequired();

			// Customer ile ilişki (1-N)
			builder.HasOne(e => e.Customer)
				   .WithMany(c => c.Representatives)
				   .HasForeignKey(e => e.CustomerID)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}

}
