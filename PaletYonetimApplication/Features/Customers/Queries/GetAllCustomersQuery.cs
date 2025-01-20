using PaletYonetimApplication.DTOs;
using MediatR;


namespace PaletYonetimApplication.Features.Customers.Queries
{
	public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
	{
	}
}
