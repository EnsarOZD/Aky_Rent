using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Extensions
{
	public static class PaletEndpoints
	{
		public static void MapPaletEndpoit(this WebApplication app)
		{
			app.MapGet("/api/palet/list", (AppDbContext context) =>
			{
				try
				{
					var palets = context.Palets.ToList();
					return Results.Ok(palets);
				}
				catch (Exception ex)
				{
					return Results.Problem($"Bir hata oluştu: {ex.Message}");
				}
			})
			.WithName("GetPaletList")
			.WithOpenApi();

			app.MapPost("/api/palet/add", async (AppDbContext context, PaletEntity palet) =>
			{

				try
				{
					context.Palets.Add(palet);
					await context.SaveChangesAsync();
					return Results.Ok(new { message = "Palet başarıyla eklendi", palet });
				}
				catch (Exception ex)
				{
					return Results.Problem($"Bir hata oluştu: {ex.Message}");
				}
			})
			.WithName("AddPalet")
			.WithOpenApi();
		}
	}
}
