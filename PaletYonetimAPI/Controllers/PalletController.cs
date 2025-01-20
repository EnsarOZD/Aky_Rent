using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimApplication.Features.Pallets.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PalletsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PalletsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var pallets = await _mediator.Send(new GetAllPalletsQuery());
			return Ok(pallets);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var pallet = await _mediator.Send(new GetPalletByIdQuery(id));

			if (pallet == null)
			{
				return NotFound();
			}

			return Ok(pallet);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatePalletCommand command)
		{
			if (command == null)
			{
				return BadRequest("Invalid pallet data");
			}

			var palletId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = palletId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdatePalletCommand command)
		{
			if (id != command.PalletID)
			{
				return BadRequest("Pallet ID mismatch");

			}

			var result = await _mediator.Send(command);

			if (!result)
			{
				return NotFound("Pallet not found");

			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeletePalletCommand(id));

			if (!result)
				return NotFound("Pallet not found.");

			return NoContent();
		}
	}
}
