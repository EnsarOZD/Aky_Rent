using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Catergories.Commands;
using PaletYonetimApplication.Features.Catergories.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var entities = await _mediator.Send(new GetAllCategoryQuery());
			return Ok(entities);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var entity = await _mediator.Send(new GetCategoryByIdQuery(id));

			if (entity == null)
			{
				return NotFound();
			}

			return Ok(entity);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
		{
			if (command == null)
			{
				return BadRequest("Invalid category data");
			}

			var entityId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = entityId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand command)
		{
			if (id != command.CategoryID)
			{
				return BadRequest("Category ID mismatch");

			}

			var result = await _mediator.Send(command);

			if (!result)
			{
				return NotFound("Category not found");

			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteCategoryCommand(id));

			if (!result)
				return NotFound("Category not found.");

			return NoContent();
		}
	}
}
