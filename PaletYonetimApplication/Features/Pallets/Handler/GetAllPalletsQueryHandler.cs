using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Pallets.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Pallets.Handler
{
	public class GetAllPalletsQueryHandler : IRequestHandler<GetAllPalletsQuery, List<PalletDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllPalletsQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<PalletDto>> Handle(GetAllPalletsQuery request, CancellationToken cancellationToken)
		{
			var pallets = await _context.Pallets
				.Select(pallet => new PalletDto
				{
					CustomerID = pallet.CustomerID,
					PalletID = pallet.PalletID,
					RackID = pallet.RackID,
					Status = pallet.Status.ToString()
				})
				.ToListAsync(cancellationToken);

			return pallets;
		}
	}
}
