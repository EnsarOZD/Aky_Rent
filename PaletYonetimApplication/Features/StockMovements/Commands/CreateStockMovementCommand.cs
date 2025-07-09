using MediatR;
using PaletYonetimDomain.Enums;
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
		
		// Yeni alanlar
		public string MovementType { get; set; }
		public string MovementReason { get; set; }
		public int? FromLocationID { get; set; }
		public int? ToLocationID { get; set; }
		public string ReferenceNumber { get; set; }
		public string ScannedBarcode { get; set; }
		public string ScannedQRCode { get; set; }
	}
}
