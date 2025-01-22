using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Roles.Commands;
using PaletYonetimApplication.Features.Roles.Queries;
using PaletYonetimApplication.Features.Users.Commands;
using PaletYonetimApplication.Features.Users.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoleController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RoleController(IMediator mediator)
		{
			_mediator = mediator;
		}

		
		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var roles = await _mediator.Send(new GetAllRoleQuery());
			return Ok(roles);
		}

		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var role = await _mediator.Send(new GetRoleByIdQuery(id));

			if (role == null)
				return NotFound("Role not found.");

			return Ok(role);
		}

		
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
		{
			if (command == null)
				return BadRequest("Invalid role data.");

			var roleId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = roleId }, null);
		}

	
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleCommand command)
		{
			if (id != command.RoleID)
				return BadRequest("Role ID mismatch.");

			var result = await _mediator.Send(command);

			if (!result)
				return NotFound("Role not found.");

			return NoContent();
		}

		
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteRoleCommand(id));

			if (!result)
				return NotFound("Role not found.");

			return NoContent();
		}
	}
}
