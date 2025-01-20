using MediatR;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Pallets.Handler
{
	public class CreatePalletCommandHandler :IRequestHandler<CreatePalletCommand,int>
	{
		private readonly IApplicationDbContext _context;

		public CreatePalletCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle (CreatePalletCommand request,CancellationToken cancellationToken)
		{
			var pallet = new PalletEntity
			{
				RackID = request.RackID,
				CustomerID = request.CustomerID,
				Status = request.Status
			};

			_context.Pallets.Add(pallet);

			await _context.SaveChangesAsync(cancellationToken);

			return pallet.PalletID;
				
		}
	}
}
