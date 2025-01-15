using PaletYonetimDomain.Enums;

namespace PaletYonetimDomain.Entities
{
	public class PalletEntity
	{
		public int PalletID { get; set; } // Benzersiz kimlik
		public int RackID { get; set; } // Paletin bulunduğu rafın kimliği
		public int? CustomerID { get; set; } // Paletin ait olduğu müşteri (nullable)
		public PalletStatus Status { get; set; } // Paletin durumu (Boş, Dolu)

		// İlişkiler
		public RackEntity Rack { get; set; } // Rack ile ilişki
		public CustomerEntity Customer { get; set; } // Customer ile ilişki
		public ICollection<StockMovementEntity> StockMovements { get; set; } // Stok hareketleri
		public ICollection<TransactionEntity> Transactions { get; set; } // Paletle ilgili işlemler

	}
}
