using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.DTO
{
		public class PalletDto
		{
			public int PalletID { get; set; }
			public string PalletName { get; set; }
			public int RackID { get; set; }
			public int? CustomerID { get; set; }
			public string Status { get; set; }
			public DateTime CreatedTime { get; set; }
			public DateTime? UpdatedTime { get; set; }

	}
}
