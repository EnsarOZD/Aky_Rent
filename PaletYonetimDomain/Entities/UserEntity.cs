using PaletYonetimDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class UserEntity : BaseEntity
	{
		public int UserID { get; set; } // Benzersiz kimlik
		public string FirstName { get; set; } // Kullanıcının adı
		public string LastName { get; set; } // Kullanıcının soyadı
		public string Email { get; set; } // E-posta adresi
		public string Password { get; set; } // Şifre
		public int RoleID { get; set; } // Kullanıcının rolü (FK)

		// Navigation Properties
		public RoleEntity Role { get; set; } // Rol ile ilişki
		public ICollection<TransactionEntity> Transactions { get; set; } // Kullanıcının yaptığı işlemler

		// Computed Property
		public string FullName => $"{FirstName} {LastName}"; // Ad ve soyadı birleştirir
	}
}
