using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Users.Commands;
using PaletYonetimApplication.Features.Users.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// Tüm kullanıcıları getir
		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var users = await _mediator.Send(new GetAllUsersQuery());
			return Ok(users);
		}

		// Belirtilen ID'ye sahip kullanıcıyı getir
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var user = await _mediator.Send(new GetUserByIdQuery(id));

			if (user == null)
				return NotFound("User not found.");

			return Ok(user);
		}

		// Yeni kullanıcı oluştur
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
		{
			if (command == null)
				return BadRequest("Invalid user data.");

			var userId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = userId }, null);
		}

		// Kullanıcı güncelle
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
		{
			if (id != command.UserID)
				return BadRequest("User ID mismatch.");

			var result = await _mediator.Send(command);

			if (!result)
				return NotFound("User not found.");

			return NoContent();
		}

		// Kullanıcı sil
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteUserCommand(id));

			if (!result)
				return NotFound("User not found.");

			return NoContent();
		}
	}
}
