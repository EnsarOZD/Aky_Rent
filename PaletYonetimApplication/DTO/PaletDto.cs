namespace PaletYonetimApplication.DTO
{
	public class PaletDto
	{
		public string PaletNo { get; set; }
		public string Address { get; set; } // Formatlanmış adres bilgisi
		public int AddressId { get; set; }
		public string CustomerName { get; set; }
		public int CustomerId { get; set; }
		public string Situation { get; set; }
		public DateTime EnteryDate { get; set; }
		public DateTime? ExitDate { get; set; }
	}
}
