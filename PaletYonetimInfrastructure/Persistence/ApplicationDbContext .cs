using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Common;
using PaletYonetimDomain.Entities;

namespace PaletYonetimInfrastructure.Persistence
{
    public class AppDbContext : DbContext, IApplicationDbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //Veritabanı tabloları

        public DbSet<StockMovementEntity> StockMovements { get; set; }
        public DbSet<PalletEntity> Pallets { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<RackEntity> Racks { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<RepresentativeEntity> Representatives { get; set; }
		public DbSet<ConfigurationSetting> ConfigurationSettings { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


        }

		// SaveChanges Override
		public override int SaveChanges()
		{
			SetTimestamps();
			return base.SaveChanges();
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			SetTimestamps();
			return await base.SaveChangesAsync(cancellationToken);
		}

		// CreatedTime ve UpdatedTime değerlerini ayarla
		private void SetTimestamps()
		{
			foreach (var entry in ChangeTracker.Entries<BaseEntity>())
			{
				if (entry.State == EntityState.Added)
				{
					entry.Entity.CreatedTime = DateTime.Now;
				}
				else if (entry.State == EntityState.Modified)
				{
					entry.Entity.UpdatedTime = DateTime.Now;
				}
			}
		}

	}
}
