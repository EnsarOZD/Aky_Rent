using Microsoft.AspNetCore.Mvc;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Data;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly AppDbContext _context;
		public CustomerController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost("Add")]
		public IActionResult Add([FromBody] CustomerEntity customer)
		{
			
			try
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();
				return Ok(new { message = "Müşteri başarıyla eklendi.", customer });

			}
			catch (Exception ex)
			{

				return StatusCode(500, new { nessage = "Müşteri eklenirken hata olşutu.", error = ex.Message });
			}

		}

		[HttpGet("List")]
		public IActionResult List()
		{
			try
			{
				var customer = _context.Customers.ToList();
				return Ok(customer);
			}
			catch (Exception ex)
			{

				return StatusCode(500, new { message = "Müşterliler listelenirken bir hata oluştu.", error = ex.Message });
			}

		}
	}
}
