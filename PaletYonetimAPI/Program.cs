using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaletYonetimAPI.Extensions;
using PaletYonetimApplication.Localization;
using PaletYonetimInfrastructure.Identity;
using PaletYonetimInfrastructure.Persistence;
using PaletYonetimInfrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Global FluentValidation dil y�neticisi ayar�
ValidatorOptions.Global.LanguageManager = new CustomLanguageManager();

// Servis kay�tlar�n� extension metotlar arac�l���yla ekleyelim
builder.Services.AddCustomServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddCustomIdentity();

// Ek loglama ayarlar�
builder.Logging.ClearProviders().AddConsole();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

	// Migration'ları uygula
	context.Database.Migrate();

	// RoleSeed �a�r�s�: Roller olu�turuluyor
	var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
	await RoleSeed.SeedRolesAsync(roleManager);

	// Opsiyonel: Varsay�lan admin kullan�c�s� olu�turuluyor
	var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
	await UserSeed.SeedAdminUserAsync(userManager);

	//Seed Data'y� burada �a��r�yoruz
	await SeedData.InitializeAsync(context);
}

// Middleware'ler
app.UseCors("AllowAll"); // CORS'u etkinle�tir
app.UseHttpsRedirection();
app.UseMiddleware<PaletYonetimInfrastructure.Middlewares.GlobalExceptionMiddleware>();


app.Use(async (context, next) =>
{
	try
	{
		await next();
	}
	catch (FluentValidation.ValidationException ex)
	{
		// Validation hatalar�n� HTTP yan�t�na ekleyin
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