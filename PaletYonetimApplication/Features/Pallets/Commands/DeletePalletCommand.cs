using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Pallets.Commands
{
	public class DeletePalletCommand : IRequest<bool> // Başarılıysa true döner
	{
		public int PalletID { get; set; }

		public DeletePalletCommand(int palletId)
		{
			PalletID = palletId;
		}
	}
}
