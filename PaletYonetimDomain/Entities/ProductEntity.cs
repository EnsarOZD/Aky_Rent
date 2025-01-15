using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class ProductEntity
	{
		public int ProductID { get; set; } // Benzersiz kimlik
		public string Name { get; set; } // Ürün adı
		public string Barcode { get; set; } // Barkod numarası
		public string Description { get; set; } // Ürün açıklaması
		public string Unit { get; set; } // Birim (ör. kg, adet, litre)
		public int CategoryID { get; set; } // Kategori kimliği (FK)
		public string CustomerStockCode { get; set; } // Müşteriye özel stok kodu

		// Navigation Properties
		public CategoryEntity Category { get; set; } // Kategori ile ilişki
		public ICollection<StockMovementEntity> StockMovements { get; set; } // Ürün hareketleri
	}
}
