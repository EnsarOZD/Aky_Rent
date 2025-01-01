using Microsoft.AspNetCore.Mvc;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class RackAddressController : ControllerBase
	{
		private readonly AppDbContext _context;
		public RackAddressController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost("Add")]
		public IActionResult Add([FromBody] RackAddressEntity address)
		{
			
			try
			{
				_context.RackAddress.Add(address);
				_context.SaveChanges();
				return Ok(new { message = "Raf adresi başarıyla eklendi.", address });

			}
			catch (Exception ex)
			{

				return StatusCode(500, new { nessage = "Raf adresi eklenirken hata olşutu.", error = ex.Message });
			}

		}

		[HttpGet("List")]
		public IActionResult List()
		{
			try
			{
				var address = _context.RackAddress.ToList();
				return Ok(address);
			}
			catch (Exception ex)
			{

				return StatusCode(500, new { message = "Raf adresleri listelenirken bir hata oluştu.", error = ex.Message });
			}

		}
	}
}
