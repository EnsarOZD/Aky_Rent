using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Customers.Commands;
using PaletYonetimApplication.Features.Customers.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CustomersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var entities = await _mediator.Send(new GetAllCustomersQuery());
			return Ok(entities);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var entity = await _mediator.Send(new GetCustomerByIdQuery(id));

			if (entity == null)
			{
				return NotFound();
			}

			return Ok(entity);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
		{
			if (command == null)
			{
				return BadRequest("Invalid customer data");
			}

			var entityId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = entityId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerCommand command)
		{
			if (id != command.CustomerID)
			{
				return BadRequest("Customer ID mismatch");

			}

			var result = await _mediator.Send(command);

			if (!result)
			{
				return NotFound("Customer not found");

			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteCustomerCommand(id));

			if (!result)
				return NotFound("Customer not found.");

			return NoContent();
		}
	}
}
