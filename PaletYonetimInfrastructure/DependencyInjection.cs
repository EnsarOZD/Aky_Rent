using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaletYonetimApplication.Interfaces;
using PaletYonetimInfrastructure.Persistence;

namespace PaletYonetimInfrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddScoped<IApplicationDbContext>(provider => provider.GetService<AppDbContext>());

			return services;
		}
	}
}
