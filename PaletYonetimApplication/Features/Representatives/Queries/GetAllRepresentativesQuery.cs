using MediatR;
using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Features.Representatives.Queries
{
	public class GetAllRepresentativesQuery : IRequest<List<RepresentativeDto>>
	{

	}
}
