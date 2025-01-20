using MediatR;

namespace PaletYonetimApplication.Features.Racks.Commands
{
	public class DeleteRackCommand : IRequest<bool> // Başarılıysa true döner
	{
		public int RackID { get; set; }

		public DeleteRackCommand(int rackId)
		{
			RackID = rackId;
		}
	}
}
