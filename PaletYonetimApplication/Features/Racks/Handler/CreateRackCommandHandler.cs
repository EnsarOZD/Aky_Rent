using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimApplication.Features.Racks.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.Features.Racks.Handler
{
	public class CreateRackCommandHandler : IRequestHandler<CreateRackCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateRackCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateRackCommand request, CancellationToken cancellationToken)
		{
			var rack = new RackEntity
			{
				CorridorNumber=request.CorridorNumber,
				Corridor=Enum.Parse<CorridorDirection>(request.Corridor),
				Floor=request.Floor,
				Row=request.Row,
				IsOccupied=false,
				UsageType=Enum.Parse<RackUsageType>(request.UsageType)
								
			};

			_context.Racks.Add(rack);

			await _context.SaveChangesAsync(cancellationToken);

			return rack.RackID;

		}
	}
}
