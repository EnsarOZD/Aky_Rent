using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class RepresentativeEntity
	{
		public int RepresentativeID { get; set; } // Benzersiz kimlik
		public int CustomerID { get; set; } // Müşteri kimliği (FK)
		public int? UserID { get; set; } // Kullanıcı kimliği (FK, opsiyonel)
		public string Name { get; set; } // Temsilci adı
		public string Phone { get; set; } // Telefon numarası
		public string Email { get; set; } // E-posta adresi
		public bool IsPrimary { get; set; } // Ana iletişim kişisi mi?

		// Navigation Property
		public CustomerEntity Customer { get; set; } // Müşteri ile ilişki
		public UserEntity User { get; set; } // Kullanıcı ile ilişki
	}
}
