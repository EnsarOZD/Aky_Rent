using MediatR;
using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Features.StockMovements.Queries
{
	public class GetStockMovementByIdQuery : IRequest<StockMovementDto>
	{
		public int StockMovementID { get; set; }

		public GetStockMovementByIdQuery(int stockMovementID)
		{
			StockMovementID = stockMovementID;
		}
	}
}