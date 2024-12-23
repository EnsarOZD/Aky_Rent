using Microsoft.AspNetCore.Mvc;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class PaletController : ControllerBase
	{
		private readonly AppDbContext _context;
		public PaletController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost("Add")]
		public IActionResult Add([FromBody] PaletEntity palet)
		{
			try
			{
				_context.Palets.Add(palet);
				_context.SaveChanges();
				return Ok(new { message = "Palet başarıyla eklendi.", palet });

			}
			catch (Exception ex)
			{

				return StatusCode(500, new { nessage = "Palet eklenirken hata olşutu.", error = ex.Message });
			}

		}

		[HttpGet("List")]
		public IActionResult List()
		{
			try
			{
				var palets = _context.Palets.ToList();
				return Ok(palets);
			}
			catch (Exception ex)
			{

				return StatusCode(500, new { message = "Paletler listelenirken bir hata oluştu.", error = ex.Message });
			}

		}
	}
}
