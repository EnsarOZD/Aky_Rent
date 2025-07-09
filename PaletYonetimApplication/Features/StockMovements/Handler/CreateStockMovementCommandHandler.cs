using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.StockMovements.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.StockMovements.Handler
{
	public class CreateStockMovementCommandHandler : IRequestHandler<CreateStockMovementCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateStockMovementCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateStockMovementCommand request, CancellationToken cancellationToken)
		{
			// Mevcut stok seviyesini hesapla
			var currentStock = await _context.StockMovements
				.Where(sm => sm.PalletID == request.PalletID && sm.ProductID == request.ProductID)
				.SumAsync(sm => sm.Quantity, cancellationToken);

			// Hareket türüne göre stok seviyesini güncelle
			var movementType = Enum.Parse<MovementType>(request.MovementType);
			var newStockBalance = movementType switch
			{
				MovementType.In => currentStock + request.Quantity,
				MovementType.Out => currentStock - request.Quantity,
				MovementType.Transfer => currentStock, // Transfer sadece konum değiştirir
				MovementType.Adjustment => request.Quantity, // Sayım düzeltmesi
				MovementType.Return => currentStock + request.Quantity,
				_ => currentStock
			};

			var stockMovement = new StockMovementEntity
			{
				PalletID = request.PalletID,
				TransactionID = request.TransactionID,
				ProductID = request.ProductID,
				Quantity = request.Quantity,
				Note = request.Note,
				Date = DateTime.Now,
				MovementType = movementType,
				MovementReason = Enum.Parse<MovementReason>(request.MovementReason),
				FromLocationID = request.FromLocationID,
				ToLocationID = request.ToLocationID,
				ReferenceNumber = request.ReferenceNumber,
				ScannedBarcode = request.ScannedBarcode,
				ScannedQRCode = request.ScannedQRCode,
				StockBalanceAfter = newStockBalance
			};

			_context.StockMovements.Add(stockMovement);
			await _context.SaveChangesAsync(cancellationToken);

			return stockMovement.StockMovementID;
		}
	}
}
