using PaletYonetimApplication.DTOs;
using MediatR;


namespace PaletYonetimApplication.Features.Customers.Queries
{
	// Belirli bir müşteri ID'sine göre müşteri bilgilerini getirmek için kullanılan query
	public class GetCustomerByIdQuery : IRequest<CustomerDto>
	{
		// Sorgu için gereken müşteri ID'si
		public int CustomerID { get; set; }

		// Constructor: Bu, query'yi oluştururken gerekli parametreyi (CustomerID) set eder
		public GetCustomerByIdQuery(int customerId)
		{
			CustomerID = customerId; // Property'e parametreyi ata
		}
	}
}
