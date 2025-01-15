using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimDomain.Enums
{
	public enum TransactionType
	{
		Ekleme,          // Yeni bir palet eklenmesi
		Taşıma,          // Paletin başka bir rafa taşınması
		Silme,           // Paletin silinmesi
		ÜrünEkleme,      // Palete ürün eklenmesi
		ÜrünÇıkarma      // Paletten ürün çıkarılması
	}
}
