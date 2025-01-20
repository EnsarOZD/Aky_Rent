using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimApplication.Features.Pallets.Handler
{
	public class CreatePalletCommandHandler : IRequestHandler<CreatePalletCommand, int>
	{
		private readonly IApplicationDbContext _context;
		private readonly IPrefixService _prefixService;

		public CreatePalletCommandHandler(IApplicationDbContext context, IPrefixService prefixService)
		{
			_context = context;
			_prefixService = prefixService;
		}

		public async Task<int> Handle(CreatePalletCommand request, CancellationToken cancellationToken)
		{
			int nextPalletNumber = 1;

			if (await _context.Pallets.AnyAsync(cancellationToken))
			{
				nextPalletNumber = await _context.Pallets
					.MaxAsync(p => p.PalletNumber, cancellationToken) + 1;
			}
			var prefix = await _prefixService.GetPrefixAsync(cancellationToken);
			var palletName = $"{prefix}-{nextPalletNumber:D3}";

			var pallet = new PalletEntity
			{
				Prefix = prefix,
				PalletNumber = nextPalletNumber,
				RackID = request.RackID,
				CustomerID = request.CustomerID,
				Status = request.Status,
				PalletName=palletName
				
			};

			_context.Pallets.Add(pallet);

			await _context.SaveChangesAsync(cancellationToken);

			return pallet.PalletID;

		}
	}
}
