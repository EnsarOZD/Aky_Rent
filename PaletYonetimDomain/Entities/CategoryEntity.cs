using PaletYonetimDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Entities
{
	public class CategoryEntity : BaseEntity
	{
		public int CategoryID { get; set; } // Benzersiz kimlik
		public string CategoryName { get; set; } // Kategori adı
		public string Description { get; set; } // Kategori açıklaması

		// Navigation Properties
		public ICollection<ProductEntity> Products { get; set; } // Kategorideki ürünler
	}
}
