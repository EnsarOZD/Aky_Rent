using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Transactions.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Transactions.Handler
{
	public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllTransactionsQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
		{
			return await _context.Transactions
				.Select(t => new TransactionDto
				{
					TransactionID = t.TransactionID,
					PalletID = t.PalletID,
					ActionType = t.ActionType.ToString(),
					Date = t.Date,
					UserID = t.UserID
				})
				.ToListAsync(cancellationToken);
		}
	}
}
