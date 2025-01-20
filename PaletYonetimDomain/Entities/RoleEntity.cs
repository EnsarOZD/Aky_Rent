using PaletYonetimDomain.Common;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class RoleEntity : BaseEntity
	{
		public int RoleID { get; set; } // Benzersiz kimlik
		public UserRole RoleName { get; set; } // Rol adı (enum)

		// Navigation Properties
		public ICollection<UserEntity> Users { get; set; } // Roldeki kullanıcılar
	}
}
