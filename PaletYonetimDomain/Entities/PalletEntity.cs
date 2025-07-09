using PaletYonetimDomain.Common;
using PaletYonetimDomain.Enums;

namespace PaletYonetimDomain.Entities
{
	public class PalletEntity:BaseEntity
	{
		public int PalletID { get; set; } // Benzersiz kimlik
		public int RackID { get; set; } // Paletin bulunduğu rafın kimliği
		public int? CustomerID { get; set; } // Paletin ait olduğu müşteri (nullable)
		public PalletStatus Status { get; set; } // Paletin durumu (Boş, Dolu)
		public int PalletNumber { get; set; } // Benzersiz numara
		public string PalletName { get; set; }
		public string Prefix { get; set; }
		public string Barcode { get; set; } // Palet barkodu
		public string QRCode { get; set; } // Palet QR kodu

		// İlişkiler
		public RackEntity Rack { get; set; } // Rack ile ilişki
		public CustomerEntity Customer { get; set; } // Customer ile ilişki
		public ICollection<StockMovementEntity> StockMovements { get; set; } // Stok hareketleri
		public ICollection<TransactionEntity> Transactions { get; set; } // Paletle ilgili işlemler
				

	}
}
