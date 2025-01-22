using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.Features.Transactions.Commands;
using PaletYonetimApplication.Features.Transactions.Queries;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TransactionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TransactionsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var transactions = await _mediator.Send(new GetAllTransactionsQuery());
			return Ok(transactions);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var transaction = await _mediator.Send(new GetTransactionByIdQuery(id));

			if (transaction == null)
				return NotFound();

			return Ok(transaction);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateTransactionCommand command)
		{
			if (command == null)
				return BadRequest("Invalid transaction data.");

			var transactionId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = transactionId }, null);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateTransactionCommand command)
		{
			if (id != command.TransactionID)
				return BadRequest("Transaction ID mismatch.");

			var result = await _mediator.Send(command);

			if (!result)
				return NotFound("Transaction not found.");

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteTransactionCommand(id));

			if (!result)
				return NotFound("Transaction not found.");

			return NoContent();
		}
	}
}
