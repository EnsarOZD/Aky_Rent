using MediatR;

namespace PaletYonetimApplication.Features.Customers.Commands
{
	public class UpdateCustomerCommand : IRequest<bool> // Başarılıysa true döner
	{
		public int CustomerID { get; set; }
		public string CompanyName { get; set; }
		public bool IsActive { get; set; }
	}
}
