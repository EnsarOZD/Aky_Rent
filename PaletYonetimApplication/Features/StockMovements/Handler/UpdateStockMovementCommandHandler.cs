using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.StockMovements.Commands;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.StockMovements.Handler
{
	public class UpdateStockMovementCommandHandler : IRequestHandler<UpdateStockMovementCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateStockMovementCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(UpdateStockMovementCommand request, CancellationToken cancellationToken)
		{
			var stockMovement = await _context.StockMovements
				.FirstOrDefaultAsync(sm => sm.StockMovementID == request.StockMovementID, cancellationToken);

			if (stockMovement == null)
				return false;

			stockMovement.PalletID = request.PalletID;
			stockMovement.TransactionID = request.TransactionID;
			stockMovement.ProductID = request.ProductID;
			stockMovement.Quantity = request.Quantity;
			stockMovement.Note = request.Note;
			

			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
