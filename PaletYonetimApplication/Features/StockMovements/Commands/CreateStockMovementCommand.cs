using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.StockMovements.Commands
{
	public class CreateStockMovementCommand : IRequest<int>
	{
		public int PalletID { get; set; }
		public int TransactionID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public string Note { get; set; }
	}
}
