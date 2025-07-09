using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.DTO
{
	public class ProductDto
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Barcode { get; set; }
		public string QRCode { get; set; }
		public string Description { get; set; }
		public string Unit { get; set; }
		public int CategoryID { get; set; }
		public string CustomerStockCode { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
		
		// Yeni alanlar
		public string SKU { get; set; }
		public decimal Weight { get; set; }
		public decimal Length { get; set; }
		public decimal Width { get; set; }
		public decimal Height { get; set; }
		public int MinimumStockLevel { get; set; }
		public int MaximumStockLevel { get; set; }
		public int ReorderPoint { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string LotNumber { get; set; }
		public string SerialNumber { get; set; }
		public bool IsHazardous { get; set; }
		public bool RequiresColdStorage { get; set; }
		public bool IsActive { get; set; }
		
		// Navigation property bilgileri
		public string CategoryName { get; set; }
		public int CurrentStock { get; set; } // Mevcut stok seviyesi
		public bool IsLowStock { get; set; } // Düşük stok uyarısı
		public bool IsOverStock { get; set; } // Aşırı stok uyarısı
	}
}
