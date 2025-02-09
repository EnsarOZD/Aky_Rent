using Microsoft.AspNetCore.Identity;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimInfrastructure.Persistence.Seed
{
	public static class RoleSeed
	{
		public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
		{
			string[] roles = new string[]
		 {
				UserRoleEntity.Admin,
				UserRoleEntity.Employee,
				UserRoleEntity.Customer
		 };

			foreach (var role in roles)
			{
				// Eğer rol veritabanında yoksa oluştur
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new IdentityRole(role));
				}
			}
		}
	}
}
