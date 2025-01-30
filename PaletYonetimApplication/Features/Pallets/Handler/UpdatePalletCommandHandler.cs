using MediatR;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimApplication.Features.Racks.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Pallets.Handler
{
	public class UpdatePalletCommandHandler : IRequestHandler<UpdatePalletCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdatePalletCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(UpdatePalletCommand request, CancellationToken cancellationToken)
		{
			var pallet = await _context.Pallets.FindAsync(request.PalletID);

			if (pallet == null)
			{
				throw new NotFoundException($"Pallet with ID {request.PalletID} was not found.");
			}

			pallet.PalletID = request.PalletID;
			pallet.RackID = request.RackID;
			pallet.CustomerID = request.CustomerID;
			pallet.Status = request.Status;
			

			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
}
