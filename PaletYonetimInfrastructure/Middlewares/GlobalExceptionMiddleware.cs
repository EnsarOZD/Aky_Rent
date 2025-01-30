using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PaletYonetimApplication.Exceptions;
using ValidationException = FluentValidation.ValidationException;

namespace PaletYonetimInfrastructure.Middlewares
{
	public class GlobalExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<GlobalExceptionMiddleware> _logger;

		public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/json";

			object response = new
			{
				Message = "An unexpected error occurred.",
				StatusCode = StatusCodes.Status500InternalServerError,
				ErrorCode = "500",
				Errors = (IEnumerable<string>)null // Varsayılan olarak null
			};

			switch (ex)
			{
				case ValidationException validationException:
					response = new
					{
						Message = "Validation failed.",
						StatusCode = StatusCodes.Status400BadRequest,
						Errors = validationException.Errors.Select(e => e.ErrorMessage),
						ErrorCode = "400"
					};
					context.Response.StatusCode = StatusCodes.Status400BadRequest;
					break;

				case NotFoundException notFoundException:
					response = new
					{
						Message = notFoundException.Message,
						StatusCode = StatusCodes.Status404NotFound,
						Errors = (IEnumerable<string>)null, // Bu hata türü için Errors boş olabilir
						ErrorCode = "404"
					};
					context.Response.StatusCode = StatusCodes.Status404NotFound;
					break;

				default:
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;
					break;
			}

			await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
		}
	}

	public class ErrorDetails
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }
	}
}
