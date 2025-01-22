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
	public class DeleteStockMovementCommandHandler : IRequestHandler<DeleteStockMovementCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteStockMovementCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(DeleteStockMovementCommand request, CancellationToken cancellationToken)
		{
			var stockMovement = await _context.StockMovements
				.FirstOrDefaultAsync(sm => sm.StockMovementID == request.StockMovementID, cancellationToken);

			if (stockMovement == null)
				return false;

			_context.StockMovements.Remove(stockMovement);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
