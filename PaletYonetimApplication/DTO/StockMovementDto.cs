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

	}
}
