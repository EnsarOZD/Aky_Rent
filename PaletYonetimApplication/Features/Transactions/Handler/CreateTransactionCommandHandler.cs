using MediatR;
using PaletYonetimApplication.Features.Transactions.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Transactions.Handler
{
	public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateTransactionCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
		{
			var transaction = new TransactionEntity
			{
				PalletID = request.PalletID,
				ActionType = Enum.Parse<TransactionType>(request.ActionType),
				Date = request.Date,
				UserID = request.UserID
			};

			_context.Transactions.Add(transaction);
			await _context.SaveChangesAsync(cancellationToken);

			return transaction.TransactionID;
		}
	}
}
