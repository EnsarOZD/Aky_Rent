using PaletYonetimDomain.Common;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class TransactionEntity : BaseEntity
	{
		public int TransactionID { get; set; } // Benzersiz işlem kimliği
		public int PalletID { get; set; } // İşlemde yer alan palet
		public TransactionType ActionType { get; set; } // İşlem türü
		public DateTime Date { get; set; } // İşlemin tarihi
		public int UserID { get; set; } // İşlemi yapan kullanıcı

		// Navigation Properties
		public PalletEntity Pallet { get; set; } // Palet ile ilişki
		public UserEntity User { get; set; } // Kullanıcı ile ilişki
		public ICollection<StockMovementEntity> StockMovements { get; set; } // Stok hareketleri
	}
}
