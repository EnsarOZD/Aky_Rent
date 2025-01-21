using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.DTO
{
	public class RepresentativeDto
	{
		public int RepresentativeID { get; set; } 
		public int CustomerID { get; set; } 
		public int? UserID { get; set; } 
		public string Name { get; set; } 
		public string Phone { get; set; } 
		public string Email { get; set; } 
		public bool IsPrimary { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
	}
}
