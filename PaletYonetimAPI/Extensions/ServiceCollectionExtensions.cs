using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PaletYonetimApplication.Behaviors;
using PaletYonetimApplication.Interfaces;
using PaletYonetimApplication;
using PaletYonetimInfrastructure.Converters;
using PaletYonetimInfrastructure.Identity;
using PaletYonetimInfrastructure.Persistence;
using PaletYonetimInfrastructure.Services;
using PaletYonetimInfrastructure;
using System.Text.Json.Serialization;
using PaletYonetimApplication.MappingProfiles;
using PaletYonetimApplication.Services;


namespace PaletYonetimAPI.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCustomServices(this IServiceCollection services, string connectionString)
		{
			// Swagger & Endpoints
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			// Infrastructure (örneğin: DbContext, Seed işlemleri, vs.)
			services.AddInfrastructure(connectionString);

			// MediatR, FluentValidation ve Pipeline Behavior
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
			services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			// IUserService arayüzü için somut implementasyonu kaydedin:
			services.AddScoped<IUserService, UserService>();

			// AutoMapper profilinizi ekleyin. 
			// Genellikle profilin bulunduğu assembly’i belirterek tüm profilleri otomatik yükleyebilirsiniz:
			services.AddAutoMapper(typeof(UserProfile).Assembly);

			// Uygulama servisleri (örneğin: IPrefixService)
			services.AddScoped<IPrefixService, PrefixService>();
			services.AddScoped<IStockLevelService, StockLevelService>();
			services.AddScoped<IBarcodeService, BarcodeService>();
			services.AddScoped<IAuditLogService, AuditLogService>();
			services.AddHttpContextAccessor();
	

			// CORS
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyMethod()
						  .AllowAnyHeader();
				});
			});

			// MVC, FluentValidation ve JsonOptions
			services.AddControllers()
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

			return services;
		}

		public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
		{
			// Identity servislerini ayrı olarak ekliyoruz
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			return services;
		}
	}
}
