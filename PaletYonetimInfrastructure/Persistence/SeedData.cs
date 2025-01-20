using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence
{
	public class SeedData
	{
		public static async Task InitializeAsync(AppDbContext context)
		{
			// Eğer veritabanı zaten doluysa seed işlemini yapma
			if (await context.Customers.AnyAsync() || await context.Racks.AnyAsync())
				return;

			// Müşteriler
			var customers = new List<CustomerEntity>
			{
				new CustomerEntity { CompanyName = "ABC Logistics", IsActive = true },
				new CustomerEntity { CompanyName = "XYZ Transport", IsActive = true },
			};
			context.Customers.AddRange(customers);

			// Raflar
			var racks = new List<RackEntity>
			{
				new RackEntity { CorridorNumber = 1, Corridor = CorridorDirection.K, Floor = 2, Row = 1, IsOccupied = false, UsageType = RackUsageType.Kiralık },
				new RackEntity { CorridorNumber = 1, Corridor = CorridorDirection.G, Floor = 2, Row = 2, IsOccupied = false, UsageType = RackUsageType.Stok },
			};
			context.Racks.AddRange(racks);

			// ConfigurationSettings
			var configurations = new List<ConfigurationSetting>
			{
				new ConfigurationSetting { Key = "DefaultPrefix", Value = "PLT" }
			};
			context.ConfigurationSettings.AddRange(configurations);

			// Veritabanına kaydet
			await context.SaveChangesAsync();
		}
	}
}
