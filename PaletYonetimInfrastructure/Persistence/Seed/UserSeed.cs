using Microsoft.AspNetCore.Identity;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Identity;

namespace PaletYonetimInfrastructure.Persistence.Seed
{
	public static class UserSeed
	{
		public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
		{
			var adminEmail = "admin@example.com";
			var adminPassword = "Admin123!";
			var adminUser = await userManager.FindByEmailAsync(adminEmail);

			if (adminUser == null)
			{
				adminUser = new ApplicationUser
				{
					UserName = adminEmail,
					Email = adminEmail,
					FirstName = "Admin",
					LastName = "User",
					CreatedTime = DateTime.Now
				};

				var result = await userManager.CreateAsync(adminUser, adminPassword);
				if (result.Succeeded)
				{
					// Oluşturulan admin kullanıcısına, Domain katmanında tanımlı yönetici rolünü atıyoruz
					await userManager.AddToRoleAsync(adminUser, UserRoleEntity.Admin);
				}
			}
			else
			{
				// Kullanıcı zaten var, sadece rolünü kontrol et
				var roles = await userManager.GetRolesAsync(adminUser);
				if (!roles.Contains(UserRoleEntity.Admin))
				{
					await userManager.AddToRoleAsync(adminUser, UserRoleEntity.Admin);
				}
			}
		}
	}
}
