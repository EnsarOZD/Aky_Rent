using MediatR;
using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Features.Representatives.Queries
{
	public class GetRepresentativeByIdQuery : IRequest<RepresentativeDto>
	{
		public int RepresentativeId { get; set; }

		public GetRepresentativeByIdQuery(int representativeId)
		{
			RepresentativeId = representativeId;
		}
	}
}
