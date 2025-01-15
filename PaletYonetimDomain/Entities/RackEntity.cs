using PaletYonetimDomain.Enums;

namespace PaletYonetimDomain.Entities
{
	public class RackEntity
	{
		public int RackID { get; set; } // Benzersiz kimlik
		public int CorridorNumber { get; set; } // Koridor numarası (1-4)
		public CorridorDirection Corridor { get; set; } // Koridor yönü (K veya G)
		public int Floor { get; set; } // Kat numarası (2, 3, veya 4)
		public int Row { get; set; } // Sıra numarası (1-60)
		public bool IsOccupied { get; set; } // Dolu mu?
		public RackUsageType UsageType { get; set; } // Kullanım türü (ör. "Kiralık", "Stok")

		// Computed property
		public string RackName => $"{CorridorNumber}{Corridor}-{Floor:D2}-{Row:D2}";

		// Navigation Property
		public ICollection<PalletEntity> Pallets { get; set; } // Bu raftaki paletler

	}
}
