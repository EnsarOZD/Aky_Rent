using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTOs;
using PaletYonetimApplication.Features.Customers.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Customers.Handler
{
	public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllCustomersQueryHandler (IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
		{
			var customers = await _context.Customers
				.Select(customer => new CustomerDto
				{
					CustomerID = customer.CustomerID,
					CompanyName = customer.CompanyName,
					IsActive = customer.IsActive
				})
				.ToListAsync(cancellationToken);

			return customers;
		}
	}
}
