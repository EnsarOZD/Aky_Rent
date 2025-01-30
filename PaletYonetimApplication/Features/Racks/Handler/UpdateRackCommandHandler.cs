using MediatR;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Racks.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.Features.Racks.Handler
{
	public class UpdateRackCommandHandler : IRequestHandler<UpdateRackCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateRackCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(UpdateRackCommand request, CancellationToken cancellationToken)
		{
			var rack = await _context.Racks.FindAsync(request.RackID);

			if (rack == null)
			{
				throw new NotFoundException($"Rack with ID {request.RackID} was not found.");
			}

			rack.CorridorNumber = request.CorridorNumber;
			rack.Corridor = Enum.Parse<CorridorDirection>(request.Corridor);
			rack.Floor = request.Floor;
			rack.Row = request.Row;
			rack.UsageType = Enum.Parse<RackUsageType>(request.UsageType);		

			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
}
