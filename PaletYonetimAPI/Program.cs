using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication;
using PaletYonetimApplication.Interfaces;
using PaletYonetimInfrastructure;
using PaletYonetimInfrastructure.Converters;
using PaletYonetimInfrastructure.Persistence;
using PaletYonetimInfrastructure.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"))
	.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly)) // MediatR'� do�ru bir �ekilde yap�land�r�n
	.AddControllers().AddJsonOptions(options =>
	{
		// JSON tarih format�n� g�ncelleme
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Enum i�in string d�n��t�rme
		options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
		options.JsonSerializerOptions.WriteIndented = true;
		options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter("dd-MM-yyyy HH:mm"));
	});
builder.Services.AddScoped<IPrefixService, PrefixService>();



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



// Varsay�lan loglama ayarlar�n� kontrol et
builder.Logging
	.ClearProviders() // Eski log sa�lay�c�lar� temizle
	.AddConsole();    // Konsol loglama ekle



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

	if (app.Environment.IsDevelopment())
	{
		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}


	//Seed Data'y� burada �a��r�yoruz
	await SeedData.InitializeAsync(context);
}

// Middleware'ler
app.UseCors("AllowAll"); // CORS'u etkinle�tir
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	
}

app.MapControllers();


app.Run();