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
				.Include(sm => sm.Product)
				.Include(sm => sm.Pallet)
				.Include(sm => sm.FromLocation)
				.Include(sm => sm.ToLocation)
				.Select(sm => new StockMovementDto
				{
					StockMovementID = sm.StockMovementID,
					PalletID = sm.PalletID,
					TransactionID = sm.TransactionID,
					ProductID = sm.ProductID,
					Quantity = sm.Quantity,
					Date = sm.Date,
					Note = sm.Note,
					StockBalanceAfter = sm.StockBalanceAfter,
					MovementType = sm.MovementType.ToString(),
					MovementReason = sm.MovementReason.ToString(),
					FromLocationID = sm.FromLocationID,
					ToLocationID = sm.ToLocationID,
					ApprovedBy = sm.ApprovedBy,
					ApprovedAt = sm.ApprovedAt,
					ScannedBarcode = sm.ScannedBarcode,
					ScannedQRCode = sm.ScannedQRCode,
					ReferenceNumber = sm.ReferenceNumber,
					ProductName = sm.Product.Name,
					PalletName = sm.Pallet.PalletName,
					FromLocationName = sm.FromLocation != null ? sm.FromLocation.RackName : null,
					ToLocationName = sm.ToLocation != null ? sm.ToLocation.RackName : null
				})
				.ToListAsync(cancellationToken);

			return stockMovements;
		}
	}
}
