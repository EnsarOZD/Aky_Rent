using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Interfaces;
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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


        }

    }
}
