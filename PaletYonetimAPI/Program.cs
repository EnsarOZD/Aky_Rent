using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaletYonetimAPI.Extensions;
using PaletYonetimApplication.Localization;
using PaletYonetimInfrastructure.Identity;
using PaletYonetimInfrastructure.Persistence;
using PaletYonetimInfrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Global FluentValidation dil yöneticisi ayarı
ValidatorOptions.Global.LanguageManager = new CustomLanguageManager();

// Servis kayıtlarını extension metotlar aracılığıyla ekleyelim
builder.Services.AddCustomServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddCustomIdentity();

// Ek loglama ayarları
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

	// RoleSeed çağrısı: Roller oluşturuluyor
	var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
	await RoleSeed.SeedRolesAsync(roleManager);

	// Opsiyonel: Varsayılan admin kullanıcısı oluşturuluyor
	var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
	await UserSeed.SeedAdminUserAsync(userManager);

	//Seed Data'yı burada çağırıyoruz
	await SeedData.InitializeAsync(context);
}

// Middleware'ler
app.UseCors("AllowAll"); // CORS'u etkinleştir
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
		// Validation hatalarını HTTP yanıtına ekleyin
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