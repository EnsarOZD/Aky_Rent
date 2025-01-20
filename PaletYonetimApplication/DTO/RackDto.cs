using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.DTO
{
	public class RackDto
	{
		public int RackID { get; set; }
		public int CorridorNumber { get; set; }
		public string Corridor { get; set; } // Kuzey veya Güney
		public int Floor { get; set; }
		public int Row { get; set; }
		public bool IsOccupied { get; set; }
		public string UsageType { get; set; } // Kiralık veya Stok
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
	}
}
