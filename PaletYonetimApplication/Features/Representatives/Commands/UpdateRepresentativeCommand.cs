using MediatR;

namespace PaletYonetimApplication.Features.Representatives.Commands
{
	public class UpdateRepresentativeCommand : IRequest<bool>
	{
		public int RepresentativeID { get; set; }
		public int CustomerID { get; set; }
		public int? UserID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool IsPrimary { get; set; }

	}
}
