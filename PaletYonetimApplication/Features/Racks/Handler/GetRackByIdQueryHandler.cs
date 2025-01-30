using MediatR;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Pallets.Queries;
using PaletYonetimApplication.Features.Racks.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Pallets.Handler
{
	public class GetRackByIdQueryHandler : IRequestHandler<GetRackByIdQuery, RackDto>
	{
		private readonly IApplicationDbContext _context;

		public GetRackByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<RackDto> Handle(GetRackByIdQuery request, CancellationToken cancellationToken)
		{
			var rack = await _context.Racks.FindAsync(request.RackID);

			if (rack == null)
			{
				throw new NotFoundException($"Rack with ID {request.RackID} was not found.");
			}

			return new RackDto
			{
				Corridor=rack.Corridor.ToString(),
				CorridorNumber=rack.CorridorNumber,
				Floor=rack.Floor,
				RackID=rack.RackID,
				IsOccupied=rack.IsOccupied,
				UsageType=rack.UsageType.ToString(),
				Row=rack.Row,
				CreatedTime = rack.CreatedTime,
				UpdatedTime = rack.UpdatedTime
			};
		}
	}
}
