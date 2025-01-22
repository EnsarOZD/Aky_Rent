using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Transactions.Queries;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Transactions.Handler
{
	public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDto>
	{
		private readonly IApplicationDbContext _context;

		public GetTransactionByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<TransactionDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
		{
			var transaction = await _context.Transactions
				.FirstOrDefaultAsync(t => t.TransactionID == request.TransactionID, cancellationToken);

			if (transaction == null)
				return null;

			return new TransactionDto
			{
				TransactionID = transaction.TransactionID,
				PalletID = transaction.PalletID,
				ActionType = transaction.ActionType.ToString(),
				Date = transaction.Date,
				UserID = transaction.UserID
			};
		}
	}
}
