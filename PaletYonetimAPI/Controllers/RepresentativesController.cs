using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Representatives.Commands;
using PaletYonetimApplication.Features.Representatives.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RepresentativesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RepresentativesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var entities = await _mediator.Send(new GetAllRepresentativesQuery());
			return Ok(entities);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var entity = await _mediator.Send(new GetRepresentativeByIdQuery(id));

			if (entity == null)
			{
				return NotFound("Representative not found");
			}

			return Ok(entity);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateRepresantiveCommand command)
		{
			if (command == null)
			{
				return BadRequest("Invalid representative data");
			}

			var representativeId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = representativeId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateRepresentativeCommand command)
		{
			if (id != command.RepresentativeID)
			{
				return BadRequest("Representative ID mismatch");
			}

			var result = await _mediator.Send(command);

			if (!result)
			{
				return NotFound("Representative not found");
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteRepresentativeCommand(id));

			if (!result)
			{
				return NotFound("Representative not found.");
			}

			return NoContent();
		}
	}
}
