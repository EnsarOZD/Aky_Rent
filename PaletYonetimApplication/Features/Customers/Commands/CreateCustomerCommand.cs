using MediatR;

namespace PaletYonetimApplication.Features.Customers.Commands
{
	public class CreateCustomerCommand : IRequest<int> 
	{
		public string CompanyName { get; set; }
		public bool IsActive { get; set; }
	}
}