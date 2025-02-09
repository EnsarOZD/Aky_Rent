using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaletYonetimAPI.Extensions;
using PaletYonetimApplication.Localization;
using PaletYonetimInfrastructure.Identity;
using PaletYonetimInfrastructure.Persistence;
using PaletYonetimInfrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Global FluentValidation dil yöneticisi ayarý
ValidatorOptions.Global.LanguageManager = new CustomLanguageManager();

// Servis kayýtlarýný extension metotlar aracýlýðýyla ekleyelim
builder.Services.AddCustomServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddCustomIdentity();

// Ek loglama ayarlarý
builder.Logging.ClearProviders().AddConsole();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

	if (app.Environment.IsDevelopment())
	{
		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}

	// RoleSeed çaðrýsý: Roller oluþturuluyor
	var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
	await RoleSeed.SeedRolesAsync(roleManager);

	// Opsiyonel: Varsayýlan admin kullanýcýsý oluþturuluyor
	var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
	await UserSeed.SeedAdminUserAsync(userManager);

	//Seed Data'yý burada çaðýrýyoruz
	await SeedData.InitializeAsync(context);
}

// Middleware'ler
app.UseCors("AllowAll"); // CORS'u etkinleþtir
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