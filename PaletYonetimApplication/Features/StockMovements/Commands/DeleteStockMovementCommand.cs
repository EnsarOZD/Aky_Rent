using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.StockMovements.Commands
{
	public class DeleteStockMovementCommand : IRequest<bool>
	{
		public int StockMovementID { get; set; }

		public DeleteStockMovementCommand(int stockMovementID)
		{
			StockMovementID = stockMovementID;
		}
	}
}
