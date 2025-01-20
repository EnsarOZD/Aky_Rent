using MediatR;
using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Features.Racks.Queries
{
	public class GetAllRacksQuery : IRequest<List<RackDto>>
	{
	}
}
