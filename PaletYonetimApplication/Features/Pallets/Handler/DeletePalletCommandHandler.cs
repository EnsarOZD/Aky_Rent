using MediatR;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Pallets.Handler
{
	public class DeletePalletCommandHandler : IRequestHandler<DeletePalletCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeletePalletCommandHandler(IApplicationDbContext context)
		{
			_context = context; 
		}

		public async Task<bool> Handle(DeletePalletCommand request, CancellationToken cancellationToken)
		{
			var pallet = await _context.Pallets.FindAsync(request.PalletID);

			if (pallet == null)
				return false;

			_context.Pallets.Remove(pallet);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
