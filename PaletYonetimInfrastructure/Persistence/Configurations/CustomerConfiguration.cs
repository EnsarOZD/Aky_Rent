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
	public class CustomerConfiguration : BaseConfiguration<CustomerEntity>
	{
		public override void Configure(EntityTypeBuilder<CustomerEntity> builder)
		{
			base.Configure(builder);
			// Primary Key
			builder.HasKey(e => e.CustomerID);

			// Şirket adı zorunlu ve maksimum 100 karakter
			builder.Property(e => e.CompanyName)
				   .IsRequired()
				   .HasMaxLength(100);

			// IsActive varsayılan olarak true
			builder.Property(e => e.IsActive)
				   .IsRequired()
				   .HasDefaultValue(true);

			// Representatives ile ilişki (1-N)
			builder.HasMany(e => e.Representatives)
				   .WithOne(r => r.Customer)
				   .HasForeignKey(r => r.CustomerID)
				   .OnDelete(DeleteBehavior.Cascade);

			// Pallets ile ilişki (1-N)
			builder.HasMany(e => e.Pallets)
				   .WithOne(p => p.Customer)
				   .HasForeignKey(p => p.CustomerID)
				   .OnDelete(DeleteBehavior.SetNull);
		}
	}
}
