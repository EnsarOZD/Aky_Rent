﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimApplication.Features.Pallets.Queries;
using PaletYonetimApplication.Features.Racks.Commands;
using PaletYonetimApplication.Features.Racks.Queries;
using PaletYonetimDomain.Entities;
using PaletYonetimInfrastructure.Persistence;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RackController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RackController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var racks = await _mediator.Send(new GetAllRacksQuery());
			return Ok(racks);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var rack = await _mediator.Send(new GetRackByIdQuery(id));

			if (rack == null)
			{
				return NotFound();
			}

			return Ok(rack);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateRackCommand command)
		{
			if (command == null)
			{
				return BadRequest("Invalid pallet data");
			}

			var rackId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = rackId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateRackCommand command)
		{
			if (id != command.RackID)
			{
				return BadRequest("Rack ID mismatch");

			}

			var result = await _mediator.Send(command);

			if (!result)
			{
				return NotFound("Rack not found");

			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteRackCommand(id));

			if (!result)
				return NotFound("Rack not found.");

			return NoContent();
		}
	}
}
