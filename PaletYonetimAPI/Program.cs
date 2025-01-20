using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication;
using PaletYonetimInfrastructure;
using PaletYonetimInfrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"))
	.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly)) // MediatR'ý doðru bir þekilde yapýlandýrýn
	.AddControllers();


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



// Varsayýlan loglama ayarlarýný kontrol et
builder.Logging
	.ClearProviders() // Eski log saðlayýcýlarý temizle
	.AddConsole();    // Konsol loglama ekle



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
	app.MapControllers();
}



app.Run();