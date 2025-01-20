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
	public class ConfigurationSettingConfiguration : IEntityTypeConfiguration<ConfigurationSetting>
	{
		public void Configure(EntityTypeBuilder<ConfigurationSetting> builder)
		{
			builder.HasKey(cs => cs.Id);
			builder.Property(cs => cs.Key)
				   .IsRequired()
				   .HasMaxLength(50);
			builder.Property(cs => cs.Value)
				   .IsRequired()
				   .HasMaxLength(50);
		}
	}
}
