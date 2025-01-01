using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Extensions
{
	public static class CustomerEndpoints
	{
		public static void MapCustoerEndpoint(this WebApplication app)
		{
			app.MapGet("/api/customer/list", (AppDbContext context) =>
			{
				try
				{
					var customer = context.Customers.ToList();
					return Results.Ok(customer);
				}
				catch (Exception ex)
				{
					return Results.Problem($"Bir hata oluştu: {ex.Message}");
				}
			})
			.WithName("GetCustomerList")
			.WithOpenApi();

			app.MapPost("/api/customer/add", async (AppDbContext context, CustomerEntity customer) =>
			{
				try
				{
					context.Customers.Add(customer);
					await context.SaveChangesAsync();
					return Results.Ok(new { message = "Mşteri başarıyla eklendi", customer });
				}
				catch (Exception ex)
				{
					return Results.Problem($"Bir hata oluştu: {ex.Message}");
				}
			})
			.WithName("AddCustomer")
			.WithOpenApi();
		}
	}
}
