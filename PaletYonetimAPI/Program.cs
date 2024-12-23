using Microsoft.EntityFrameworkCore;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS politikas� ekleniyor
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});

// Swagger/OpenAPI deste�i
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

	if (app.Environment.IsDevelopment())
	{
		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}
	

	// Seed Data'y� burada �a��r�yoruz
	SeedData.Initialize(context);
}

// Middleware'ler
app.UseCors("AllowAll"); // CORS'u etkinle�tir
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// API Endpoint'leri
app.MapGet("/api/palet/list", (AppDbContext context) =>
{
	try
	{
		var palets = context.Palets.ToList();
		return Results.Ok(palets);
	}
	catch (Exception ex)
	{
		return Results.Problem($"Bir hata olu�tu: {ex.Message}");
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
		return Results.Ok(new { message = "Palet ba�ar�yla eklendi", palet });
	}
	catch (Exception ex)
	{
		return Results.Problem($"Bir hata olu�tu: {ex.Message}");
	}
})
.WithName("AddPalet")
.WithOpenApi();

app.MapGet("/api/customer/list", (AppDbContext context) =>
{
	try
	{
		var customer = context.Customers.ToList();
		return Results.Ok(customer);
	}
	catch (Exception ex)
	{
		return Results.Problem($"Bir hata olu�tu: {ex.Message}");
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
		return Results.Ok(new { message = "M�teri ba�ar�yla eklendi", customer });
	}
	catch (Exception ex)
	{
		return Results.Problem($"Bir hata olu�tu: {ex.Message}");
	}
})
.WithName("AddCustomer")
.WithOpenApi();

app.Run();