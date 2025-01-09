using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Extensions;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Extensions
{
	public static class PaletEndpoints
	{
		public static void MapPaletEndpoit(this WebApplication app)
		{
			app.MapGet("/api/palet/list",async (AppDbContext context ) =>
			{
				try
				{
					var palets = await context.Palets
					.Include(p => p.RackAddress)
					.Include(p => p.Customer)
					.Select(p => p.ToDTO())
					.ToListAsync();

					return Results.Ok(palets);
				}
				catch (Exception ex)
				{
					return Results.Problem($"Bir hata oluştu: {ex.Message}");
				}
			})
			.WithName("GetPaletList")
			.WithOpenApi();

			app.MapPost("/api/palet/add", async (AppDbContext context, PaletDto paletDTO) =>
			{

				try
				{
					var paletEntity = paletDTO.ToEntity(paletDTO.AddressId, paletDTO.CustomerId);
					context.Palets.Add(paletEntity);
					await context.SaveChangesAsync();
					return Results.Ok(new { message = "Palet başarıyla eklendi", palet=paletEntity });
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
