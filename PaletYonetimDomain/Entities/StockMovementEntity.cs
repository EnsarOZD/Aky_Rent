using PaletYonetimDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class StockMovementEntity : BaseEntity
	{
		public int StockMovementID { get; set; } // Benzersiz kimlik
		public int PalletID { get; set; } // İlgili palet
		public int TransactionID { get; set; } // İlgili işlem
		public int ProductID { get; set; } // Ürün kimliği
		public int Quantity { get; set; } // Alınan/eklenen ürün miktarı
		public DateTime Date { get; set; } // Hareket tarihi
		public string Note { get; set; } // Hareketle ilgili açıklama
		public int StockBalanceAfter { get; set; } // Hareket sonrası kalan stok

		// Navigation Properties
		public PalletEntity Pallet { get; set; } // Palet ile ilişki
		public TransactionEntity Transaction { get; set; } // İşlem ile ilişki
		public ProductEntity Product { get; set; } // Ürün ile ilişki
	}
}
