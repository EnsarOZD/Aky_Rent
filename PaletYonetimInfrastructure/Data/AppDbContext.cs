using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;

namespace PaletYonetimInfrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		//Veritabanı tabloları

		public DbSet<PaletEntity> Palets { get; set; }
		public DbSet<CustomerEntity> Customers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Vertabanı ilişkileri

			modelBuilder.Entity<PaletEntity>()
				.HasOne(p => p.Customer)
				.WithMany(c => c.Palets)
				.HasForeignKey(p => p.CustomerId);
		}

	}
}
