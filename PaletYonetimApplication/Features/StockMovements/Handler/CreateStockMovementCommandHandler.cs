using MediatR;
using PaletYonetimApplication.Features.StockMovements.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
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
			var stockMovement = new StockMovementEntity
			{
				PalletID = request.PalletID,
				TransactionID = request.TransactionID,
				ProductID = request.ProductID,
				Quantity = request.Quantity,
				Note = request.Note,
				Date = DateTime.Now
			};

			_context.StockMovements.Add(stockMovement);
			await _context.SaveChangesAsync(cancellationToken);

			return stockMovement.StockMovementID;
		}
	}
}
