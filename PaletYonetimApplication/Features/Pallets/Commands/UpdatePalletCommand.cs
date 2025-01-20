using MediatR;
using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.Features.Pallets.Commands
{
	public class UpdatePalletCommand : IRequest<bool> // Başarılıysa true döner
	{
		public int PalletID { get; set; }
		public int RackID { get; set; }
		public int? CustomerID { get; set; }
		public PalletStatus Status { get; set; }
	}
}
