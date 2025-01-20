using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletYonetimDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence.Configurations
{
	public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity:BaseEntity
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.Property(e => e.CreatedTime)
				.IsRequired()
				.HasDefaultValueSql("GETDATE()");
			builder.Property(e => e.UpdatedTime)
				.IsRequired(false);
		}
	}
}
