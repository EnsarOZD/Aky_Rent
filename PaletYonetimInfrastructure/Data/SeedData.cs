namespace PaletYonetimInfrastructure.Data
{
	using PaletYonetimDomain.Entities;
	using Microsoft.EntityFrameworkCore;

	public static class SeedData
	{
		public static void Initialize(AppDbContext context)
		{
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
			}

			if (!context.Palets.Any())
			{
				context.Palets.AddRange(
					new PaletEntity
					{
						PaletNo = "P12345",
						Addres = "Raf 1 - Sütun 3",
						Situation = "Depoda",
						CustomerId = 1,
						EnteryDate = DateTime.Now
					},
					new PaletEntity
					{
						PaletNo = "P67890",
						Addres = "Raf 2 - Sütun 1",
						Situation = "Kirada",
						CustomerId = 2,
						EnteryDate = DateTime.Now,
						ExitDate = DateTime.Now.AddDays(7)
					}
				);
			}

			context.SaveChanges();
		}
	}
}
