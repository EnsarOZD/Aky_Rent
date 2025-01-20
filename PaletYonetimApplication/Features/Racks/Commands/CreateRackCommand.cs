using MediatR;

namespace PaletYonetimApplication.Features.Racks.Commands
{
	public class CreateRackCommand : IRequest<int>
	{
		public int CorridorNumber { get; set; }
		public string Corridor { get; set; }
		public int Floor { get; set; }
		public int Row { get; set; }
		public string UsageType { get; set; }
	}
}
