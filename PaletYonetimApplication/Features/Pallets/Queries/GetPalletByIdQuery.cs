using MediatR;
using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Features.Pallets.Queries
{
	public class GetPalletByIdQuery : IRequest<PalletDto>
	{
		// Sorgu için gereken müşteri ID'si
		public int PalletID { get; set; }

		// Constructor: Bu, query'yi oluştururken gerekli parametreyi (PalletID) set eder
		public GetPalletByIdQuery(int palletId)
		{
			PalletID = palletId; // Property'e parametreyi ata
		}
	}
}
