using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.DTO
{
	public class UpdateUserDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		// Gerekirse başka güncellenebilir alanlar da ekleyebilirsiniz.
	}
}
