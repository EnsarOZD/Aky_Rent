namespace PaletYonetimApplication.DTO
{
	public class TransactionDto
	{
		public int TransactionID { get; set; }
		public int PalletID { get; set; }
		public string ActionType { get; set; }
		public DateTime Date { get; set; }
		public string UserID { get; set; }

	}
}
