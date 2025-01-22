using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Transactions.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Transactions.Handler
{
	public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteTransactionCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
		{
			var transaction = await _context.Transactions
				.FirstOrDefaultAsync(t => t.TransactionID == request.TransactionID, cancellationToken);

			if (transaction == null)
				return false;

			_context.Transactions.Remove(transaction);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
