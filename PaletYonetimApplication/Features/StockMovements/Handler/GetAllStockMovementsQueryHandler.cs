using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.StockMovements.Queries;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.StockMovements.Handler
{
	public class GetAllStockMovementsQueryHandler : IRequestHandler<GetAllStockMovementsQuery, List<StockMovementDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllStockMovementsQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<StockMovementDto>> Handle(GetAllStockMovementsQuery request, CancellationToken cancellationToken)
		{
			var stockMovements = await _context.StockMovements
				.Select(sm => new StockMovementDto
				{
					StockMovementID = sm.StockMovementID,
					PalletID = sm.PalletID,
					TransactionID = sm.TransactionID,
					ProductID = sm.ProductID,
					Quantity = sm.Quantity,
					Date = sm.Date,
					Note = sm.Note,
					StockBalanceAfter = sm.StockBalanceAfter
				})
				.ToListAsync(cancellationToken);

			return stockMovements;
		}
	}
}
