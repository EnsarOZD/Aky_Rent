using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Racks.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Racks.Handler
{
	public class GetAllRacksQueryHandler : IRequestHandler<GetAllRacksQuery, List<RackDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllRacksQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<RackDto>> Handle(GetAllRacksQuery request, CancellationToken cancellationToken)
		{
			var racks = await _context.Racks
				.Select(rack => new RackDto
				{
					RackID=rack.RackID,
					CorridorNumber=rack.CorridorNumber,
					Corridor=rack.Corridor.ToString(),
					Floor=rack.Floor,
					Row=rack.Row,
					IsOccupied=rack.IsOccupied,
					UsageType=rack.UsageType.ToString(),
					CreatedTime=rack.CreatedTime,
					UpdatedTime=rack.UpdatedTime
				})
				.ToListAsync(cancellationToken);

			return racks;
		}
	}
}
