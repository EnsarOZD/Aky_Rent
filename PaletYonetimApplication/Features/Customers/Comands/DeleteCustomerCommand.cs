using MediatR;

namespace PaletYonetimApplication.Features.Customers.Commands
{
	public class DeleteCustomerCommand : IRequest<bool> // Başarılıysa true döner
	{
		public int CustomerID { get; set; }

		public DeleteCustomerCommand(int customerId)
		{
			CustomerID = customerId;
		}
	}
}
