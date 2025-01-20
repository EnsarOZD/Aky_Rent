using MediatR;

namespace PaletYonetimApplication.Features.Customers.Commands
{
	public class CreateCustomerCommand : IRequest<int> // Geriye müşteri ID'sini döner
	{
		public string CompanyName { get; set; }
		public bool IsActive { get; set; }
	}
}