using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.StockMovements.Commands;
using PaletYonetimApplication.Features.StockMovements.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
	public class StockMovementsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StockMovementsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var stockMovements = await _mediator.Send(new GetAllStockMovementsQuery());
			return Ok(stockMovements);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var stockMovement = await _mediator.Send(new GetStockMovementByIdQuery(id));

			if (stockMovement == null)
				return NotFound($"Stock Movement with ID {id} not found.");

			return Ok(stockMovement);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateStockMovementCommand command)
		{
			if (command == null)
				return BadRequest("Invalid stock movement data.");

			// Varsayılan değerleri ayarla
			if (string.IsNullOrEmpty(command.MovementType))
				command.MovementType = "In";
			
			if (string.IsNullOrEmpty(command.MovementReason))
				command.MovementReason = "Purchase";

			var createdId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetById), new { id = createdId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateStockMovementCommand command)
		{
			if (id != command.StockMovementID)
				return BadRequest("ID mismatch.");

			var result = await _mediator.Send(command);
			if (!result)
				return NotFound($"Stock Movement with ID {id} not found.");

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteStockMovementCommand(id));
			if (!result)
				return NotFound($"Stock Movement with ID {id} not found.");

			return NoContent();
		}
	}
}
