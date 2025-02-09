using MediatR;

namespace PaletYonetimApplication.Features.Representatives.Commands
{
	public class CreateRepresantiveCommand : IRequest<int>
	{
		public int CustomerID { get; set; }
		public string UserID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		
	}
}
