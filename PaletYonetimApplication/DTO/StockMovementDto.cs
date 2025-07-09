using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.DTO
{
	public class StockMovementDto
	{
		public int StockMovementID { get; set; }
		public int PalletID { get; set; }
		public int TransactionID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public DateTime Date { get; set; }
		public string Note { get; set; }
		public int StockBalanceAfter { get; set; }
		
		// Yeni alanlar
		public string MovementType { get; set; }
		public string MovementReason { get; set; }
		public int? FromLocationID { get; set; }
		public int? ToLocationID { get; set; }
		public string ApprovedBy { get; set; }
		public DateTime? ApprovedAt { get; set; }
		public string ScannedBarcode { get; set; }
		public string ScannedQRCode { get; set; }
		public string ReferenceNumber { get; set; }
		
		// Navigation property bilgileri
		public string ProductName { get; set; }
		public string PalletName { get; set; }
		public string FromLocationName { get; set; }
		public string ToLocationName { get; set; }
	}
}
