using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Transactions.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Transactions.Handler
{
	public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateTransactionCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
		{
			var transaction = await _context.Transactions
				.FirstOrDefaultAsync(t => t.TransactionID == request.TransactionID, cancellationToken);

			if (transaction == null)
				return false;

			transaction.PalletID = request.PalletID;
			transaction.ActionType = Enum.Parse<TransactionType>(request.ActionType);
			transaction.Date = request.Date;
			transaction.UserID = request.UserID;

			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
