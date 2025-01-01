using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Extensions
{
	public static class RackAddressEndpoints
	{
		public static void MapRackAddressEndpoints(this WebApplication app)
		{
			app.MapGet("/api/rackAddress/list", (AppDbContext context) =>
			{
				try
				{
					var address = context.RackAddress.ToList();
					return Results.Ok(address);
				}
				catch (Exception ex)
				{
					return Results.Problem($"Bir hata oluştu: {ex.Message}");
				}
			})
			.WithName("GetRackAddressList")
			.WithOpenApi();

			app.MapPost("/api/rackAddress/add", async (AppDbContext context, RackAddressEntity address) =>
			{
				try
				{
					context.RackAddress.Add(address);
					await context.SaveChangesAsync();
					return Results.Ok(new { message = "Raf adresi başarıyla eklendi", address });
				}
				catch (Exception ex)
				{
					return Results.Problem($"Bir hata oluştu: {ex.Message}");
				}
			})
			.WithName("AddRackAddress")
			.WithOpenApi();
		}

	}
}
