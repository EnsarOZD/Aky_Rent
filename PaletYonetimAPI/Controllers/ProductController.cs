using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Products.Commands;
using PaletYonetimApplication.Features.Products.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var entitys = await _mediator.Send(new GetAllProductsQuery());
			return Ok(entitys);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var entity = await _mediator.Send(new GetProductByIdQuery(id));

			if (entity == null)
			{
				return NotFound();
			}

			return Ok(entity);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
		{
			if (command == null)
			{
				return BadRequest("Invalid product data");
			}

			var entityId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = entityId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
		{
			if (id != command.ProductID)
			{
				return BadRequest("Product ID mismatch");

			}

			var result = await _mediator.Send(command);

			if (!result)
			{
				return NotFound("Product not found");

			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteProductCommand(id));

			if (!result)
				return NotFound("Product not found.");

			return NoContent();
		}
	}
}
