using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

public static class SeedData
{
	public static void Initialize(AppDbContext context)
	{
		// Müşteri verisi kontrol ve ekleme
		if (!context.Customers.Any())
		{
			context.Customers.AddRange(
				new CustomerEntity
				{
					Name = "Ali",
					Surname = "Veli",
					PhoneNumber = "1234567890",
					Email = "ali.veli@example.com",
					CustomerAddress = "İstanbul"
				},
				new CustomerEntity
				{
					Name = "Ayşe",
					Surname = "Yılmaz",
					PhoneNumber = "0987654321",
					Email = "ayse.yilmaz@example.com",
					CustomerAddress = "Ankara"
				}
			);
			context.SaveChanges();
		}

		// RackAddress verisi kontrol ve ekleme
		if (!context.RackAddress.Any())
		{
			var rackAddresses = new List<RackAddressEntity>();
			for (int corridor = 1; corridor <= 4; corridor++)
			{
				foreach (var side in new[] { "K", "G" })
				{
					for (int row = 1; row <= 63; row++)
					{
						for (int level = 4; level <= 6; level++)
						{
							rackAddresses.Add(new RackAddressEntity
							{
								CorridorNumber = corridor,
								CorridorSide = side,
								RowNumber = row,
								Level = level,
							});
						}
					}
				}
			}

			context.RackAddress.AddRange(rackAddresses);
			context.SaveChanges();
		}

		// Palet verisi kontrol ve ekleme
		if (!context.Palets.Any())
		{
			var rackAddresses = context.RackAddress.ToList();
			var customers = context.Customers.ToList(); // Müşteri listesini al

			if (rackAddresses.Count >= 2 && customers.Count >= 2)
			{
				context.Palets.AddRange(
					new PalletEntity
					{
						PaletNo = "P12345",
						CustomerId = customers[0].Id, // İlk müşteri
						Situation = "Depoda",
						EnteryDate = DateTime.Now,
						AddressId = rackAddresses[0].Id
						

					},
					new PalletEntity
					{
						PaletNo = "P67890",
						CustomerId = customers[1].Id, // İkinci müşteri
						Situation = "Kirada",
						EnteryDate = DateTime.Now.AddDays(-10),
						ExitDate = DateTime.Now,
						AddressId = rackAddresses[1].Id
					}
				);


				context.RackAddress.UpdateRange(rackAddresses);
				context.SaveChanges();
			}
		}
	}
}
