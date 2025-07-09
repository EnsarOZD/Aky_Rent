using PaletYonetimDomain.Common;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class ProductEntity : BaseEntity
	{
		public int ProductID { get; set; } // Benzersiz kimlik
		public string Name { get; set; } // Ürün adı
		public string Barcode { get; set; } // Barkod numarası
		public string QRCode { get; set; } // QR kod
		public string? Description { get; set; } // Ürün açıklaması
		public ProductUnit Unit { get; set; } // Birim (ör. kg, adet, litre)
		public int CategoryID { get; set; } // Kategori kimliği (FK)
		public string? CustomerStockCode { get; set; } // Müşteriye özel stok kodu
		
		// Yeni alanlar - Stok Yönetimi
		public string? SKU { get; set; } // Stock Keeping Unit
		public decimal? Weight { get; set; } // Ağırlık (kg)
		public decimal? Length { get; set; } // Uzunluk (cm)
		public decimal? Width { get; set; } // Genişlik (cm)
		public decimal? Height { get; set; } // Yükseklik (cm)
		public int? MinimumStockLevel { get; set; } // Minimum stok seviyesi
		public int? MaximumStockLevel { get; set; } // Maksimum stok seviyesi
		public int? ReorderPoint { get; set; } // Yeniden sipariş noktası
		public DateTime? ExpiryDate { get; set; } // Son kullanma tarihi
		public string? LotNumber { get; set; } // Lot numarası
		public string? SerialNumber { get; set; } // Seri numarası
		public bool IsHazardous { get; set; } // Tehlikeli madde mi?
		public bool RequiresColdStorage { get; set; } // Soğuk depo gerekiyor mu?
		public bool IsActive { get; set; } = true; // Ürün aktif mi?

		// Navigation Properties
		public CategoryEntity Category { get; set; } // Kategori ile ilişki
		public ICollection<StockMovementEntity> StockMovements { get; set; } // Ürün hareketleri
	}
}
