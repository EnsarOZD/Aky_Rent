using PaletYonetimDomain.Common;
using PaletYonetimDomain.Enums;
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
		
		// Yeni alanlar
		public MovementType MovementType { get; set; } // Hareket türü
		public MovementReason MovementReason { get; set; } // Hareket nedeni
		public int? FromLocationID { get; set; } // Önceki konum (RackID)
		public int? ToLocationID { get; set; } // Yeni konum (RackID)
		public string ApprovedBy { get; set; } // Onaylayan kullanıcı
		public DateTime? ApprovedAt { get; set; } // Onay tarihi
		public string ScannedBarcode { get; set; } // Stok hareketi sırasında taranan barkod
		public string ScannedQRCode { get; set; } // Stok hareketi sırasında taranan QR kod
		public string ReferenceNumber { get; set; } // Referans numarası (Sipariş, Fatura vb.)

		// Navigation Properties
		public PalletEntity Pallet { get; set; } // Palet ile ilişki
		public TransactionEntity Transaction { get; set; } // İşlem ile ilişki
		public ProductEntity Product { get; set; } // Ürün ile ilişki
		public RackEntity FromLocation { get; set; } // Önceki konum
		public RackEntity ToLocation { get; set; } // Yeni konum
	}
}
