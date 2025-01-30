using MediatR;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Pallets.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Pallets.Handler
{
	public class GetPalletByIdQueryHandler : IRequestHandler<GetPalletByIdQuery, PalletDto>
	{
		private readonly IApplicationDbContext _context;

		public GetPalletByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<PalletDto> Handle(GetPalletByIdQuery request, CancellationToken cancellationToken)
		{
			var pallet = await _context.Pallets.FindAsync(request.PalletID);

			if (pallet == null)
			{
				throw new NotFoundException($"Pallets with ID {request.PalletID} was not found.");
			}

			return new PalletDto
			{
				PalletID = pallet.PalletID,
				PalletName = pallet.PalletName,
				CustomerID = pallet.CustomerID,
				RackID = pallet.RackID,
				Status = pallet.Status.ToString(),
				CreatedTime = pallet.CreatedTime,
				UpdatedTime = pallet.UpdatedTime
			};
		}
	}
}
