using MediatR;

namespace PaletYonetimApplication.Features.Racks.Commands
{
	public class UpdateRackCommand : IRequest<bool> // Başarılıysa true döner
	{
		public int RackID { get; set; }
		public int CorridorNumber { get; set; }
		public string Corridor { get; set; }
		public int Floor { get; set; }
		public int Row { get; set; }
		public string UsageType { get; set; }
	}
}