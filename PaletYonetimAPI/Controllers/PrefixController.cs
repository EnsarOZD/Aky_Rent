using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Interfaces;
using PaletYonetimInfrastructure.Services;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PrefixController : ControllerBase
	{
		private readonly IPrefixService _service;

		public PrefixController(IPrefixService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetPrefix()
		{
			var prefix = await _service.GetPrefixAsync(HttpContext.RequestAborted);
			return Ok(prefix);
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePrefix([FromBody] string newPrefix)
		{
			if (string.IsNullOrWhiteSpace(newPrefix))
				return BadRequest("Geçersiz prefix değeri.");

			await _service.UpdatePrefixAsync(newPrefix, HttpContext.RequestAborted);
			return NoContent();
		}
	}

}
