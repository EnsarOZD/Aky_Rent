using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<CustomerEntity> Customers { get; }
		DbSet<PalletEntity> Pallets { get; }
		DbSet<RackEntity> Racks { get; }
		DbSet<CategoryEntity> Categories { get; }
		DbSet<ProductEntity> Products { get; }
		DbSet<RepresentativeEntity> Representatives { get; }		
		DbSet<StockMovementEntity> StockMovements { get; }
		DbSet<TransactionEntity> Transactions { get; }	
		DbSet<ConfigurationSetting> ConfigurationSettings { get; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
