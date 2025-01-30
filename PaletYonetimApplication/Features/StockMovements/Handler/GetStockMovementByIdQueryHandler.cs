using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.StockMovements.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.StockMovements.Handler
{
	public class GetStockMovementByIdQueryHandler : IRequestHandler<GetStockMovementByIdQuery, StockMovementDto>
	{
		private readonly IApplicationDbContext _context;

		public GetStockMovementByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<StockMovementDto> Handle(GetStockMovementByIdQuery request, CancellationToken cancellationToken)
		{
			var stockMovement = await _context.StockMovements
				.FirstOrDefaultAsync(sm => sm.StockMovementID == request.StockMovementID, cancellationToken);

			if (stockMovement == null)
				throw new NotFoundException($"StockMovemnet with ID {request.StockMovementID} was not found.");

			return new StockMovementDto
			{
				StockMovementID = stockMovement.StockMovementID,
				PalletID = stockMovement.PalletID,
				TransactionID = stockMovement.TransactionID,
				ProductID = stockMovement.ProductID,
				Quantity = stockMovement.Quantity,
				Date = stockMovement.Date,
				Note = stockMovement.Note,
				StockBalanceAfter = stockMovement.StockBalanceAfter
			};
		}
	}
}
