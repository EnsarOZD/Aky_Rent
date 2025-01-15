using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class PaletController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly ILogger<PaletController> _logger;
		public PaletController(AppDbContext context , ILogger<PaletController> logger)
		{
			_context = context;
			_logger = logger;
		}

		[HttpPost("Add")]
		public IActionResult Add([FromBody] PalletEntity palet)
		{
			if (palet.CustomerId==0)
			{
				return BadRequest("Müşteri ID'si gerekli.");
			}
			if (palet==null)
			{
				return BadRequest("Gönderilen palet bilgisi geçersiz.");
			}
			try
			{
				Console.WriteLine($"AddresId: {palet.AddressId}, CustomerId: {palet.CustomerId}");
				_context.Palets.Add(palet);
				_context.SaveChanges();

				_logger.LogInformation("Yeni palet eklendi. Palet ID: {Id}, Palet No: {PaletNo}, AddressId: {AddressId}, CustomerId: {CustomerId}",
			palet.Id, palet.PaletNo, palet.AddressId, palet.CustomerId);

				return Ok(new { message = "Palet başarıyla eklendi.", palet });

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Palet eklenirken hata oluştu. Hata: {ErrorMessage}", ex.Message);
				return StatusCode(500, new { nessage = "Palet eklenirken hata olşutu.", error = ex.Message });
			}

		}

		[HttpGet("List")]
		public async Task<IActionResult> List()
		{
			try
			{
				var palets = await _context.Palets
					.Include(p => p.RackAddress)
					.Include(p=>p.Customer)
					.ToListAsync();

				var paletDtoList = palets.Select(p => new PaletDto
				{
					
					PaletNo = p.PaletNo,
					Address = p.RackAddress != null
								? $"Koridor {p.RackAddress.CorridorNumber}-{p.RackAddress.CorridorSide}, Sıra {p.RackAddress.RowNumber}, Kat {p.RackAddress.Level}"
			:					 "Adres Yok",
					Situation = p.Situation,
					EnteryDate = p.EnteryDate,
					ExitDate = p.ExitDate
				}).ToList();

				return Ok(paletDtoList);
				
			}
			catch (Exception ex)
			{

				return StatusCode(500, new { message = "Paletler listelenirken bir hata oluştu.", error = ex.Message });
			}

		}
	}
}
