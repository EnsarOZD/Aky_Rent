using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class RackAddressEntity
	{
		public int Id { get; set; } // Primary Key

		public int CorridorNumber { get; set; } // Koridor numarası (1-4)
		public string CorridorSide { get; set; } // Kuzey veya Güney (K/G)
		public int RowNumber { get; set; } // Sıra numarası (1-63)
		public int Level { get; set; } // Kat numarası (4-6)

		public int? PaletId { get; set; } // Palet ile ilişki (nullable)
		public PaletEntity Palet { get; set; } // Navigation property
	}
}
