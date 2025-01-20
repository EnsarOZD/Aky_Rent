using MediatR;
using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Features.Racks.Queries
{
	public class GetRackByIdQuery : IRequest<RackDto>
	{
		// Sorgu için gereken müşteri ID'si
		public int RackID { get; set; }

		// Constructor: Bu, query'yi oluştururken gerekli parametreyi (RackID) set eder
		public GetRackByIdQuery(int rackId)
		{
			RackID = rackId; // Property'e parametreyi ata
		}
	}
}
