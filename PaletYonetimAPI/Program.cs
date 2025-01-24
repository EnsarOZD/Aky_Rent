using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication;
using PaletYonetimApplication.Behaviors;
using PaletYonetimApplication.Interfaces;
using PaletYonetimApplication.Localization;
using PaletYonetimInfrastructure;
using PaletYonetimInfrastructure.Converters;
using PaletYonetimInfrastructure.Persistence;
using PaletYonetimInfrastructure.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ValidatorOptions.Global.LanguageManager = new CustomLanguageManager();
// Add services to the container.
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"))
	.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly))
	.AddControllers()
	 .AddFluentValidation(config =>
	 {
		 config.RegisterValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
	 })
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
		options.JsonSerializerOptions.WriteIndented = true;
		options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter("dd-MM-yyyy HH:mm"));
	});

builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddScoped<IPrefixService, PrefixService>();

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
		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}


	//Seed Data'yý burada çaðýrýyoruz
	await SeedData.InitializeAsync(context);
}

// Middleware'ler
app.UseCors("AllowAll"); // CORS'u etkinleþtir
app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
	try
	{
		await next();
	}
	catch (FluentValidation.ValidationException ex)
	{
		// Validation hatalarýný HTTP yanýtýna ekleyin
		context.Response.StatusCode = 400; // Bad Request
		context.Response.Headers.Add("Validation-Errors", string.Join(", ", ex.Errors.Select(e => e.ErrorMessage)));

		await context.Response.WriteAsJsonAsync(new
		{
			Message = "Validation Failed",
			Errors = ex.Errors.Select(e => e.ErrorMessage)
		});
	}
});

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

}

app.MapControllers();


app.Run();