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

// CORS politikasý ekleniyor
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});

// Swagger/OpenAPI desteði
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Varsayýlan loglama ayarlarýný kontrol et
builder.Logging.ClearProviders(); // Eski log saðlayýcýlarý temizle
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
	

	// Seed Data'yý burada çaðýrýyoruz
	//SeedData.Initialize(context);
}

// Middleware'ler
app.UseCors("AllowAll"); // CORS'u etkinleþtir
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