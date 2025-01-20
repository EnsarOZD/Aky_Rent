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
			var customers = await _mediator.Send(new GetAllCustomersQuery());
			return Ok(customers);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

			if (customer == null)
			{
				return NotFound();
			}

			return Ok(customer);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
		{
			if (command == null)
			{
				return BadRequest("Invalid customer data");
			}

			var customerId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = customerId }, null);
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
