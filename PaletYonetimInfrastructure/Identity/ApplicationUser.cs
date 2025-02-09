using Microsoft.AspNetCore.Identity;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimInfrastructure.Identity
{
	public class ApplicationUser : IdentityUser, IApplicationUser
	{
		// Ek kişisel bilgiler
		public string FirstName { get; set; }
		public string LastName { get; set; }

		// Hesapla ve döndür: Ad ve soyadın birleşimi
		public string FullName => $"{FirstName} {LastName}";

		// Kullanıcının yaptığı işlemler (Navigation Property)
		public virtual ICollection<TransactionEntity> Transactions { get; set; }

		// İsteğe bağlı: Oluşturulma ve güncelleme zamanları
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
	}
}
