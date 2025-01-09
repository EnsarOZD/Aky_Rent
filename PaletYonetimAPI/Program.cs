using Microsoft.EntityFrameworkCore;
using PaletYonetimAPI.Extensions;
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

// Varsay�lan loglama ayarlar�n� kontrol et
builder.Logging.ClearProviders(); // Eski log sa�lay�c�lar� temizle
builder.Logging.AddConsole();    // Konsol loglama ekle

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

	if (app.Environment.IsDevelopment())
	{
		//context.Database.EnsureDeleted();
		//context.Database.EnsureCreated();
	}
	

	// Seed Data'y� burada �a��r�yoruz
	//SeedData.Initialize(context);
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
app.MapPaletEndpoit();
app.MapCustoerEndpoint();
app.MapRackAddressEndpoints();

app.Run();