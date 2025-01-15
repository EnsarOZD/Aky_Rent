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
	public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
	{
		public void Configure(EntityTypeBuilder<TransactionEntity> builder)
		{
			builder.HasKey(e => e.TransactionID);

			builder.Property(e => e.ActionType)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(e => e.Date)
				   .IsRequired();

			builder.HasOne(e => e.Pallet)
				   .WithMany(p => p.Transactions)
				   .HasForeignKey(e => e.PalletID)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(e => e.User)
				   .WithMany(u => u.Transactions)
				   .HasForeignKey(e => e.UserID)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
