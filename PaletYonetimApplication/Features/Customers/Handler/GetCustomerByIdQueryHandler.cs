using MediatR;
using PaletYonetimApplication.DTOs;
using PaletYonetimApplication.Features.Customers.Queries;
using PaletYonetimApplication.Interfaces;
using System;

namespace PaletYonetimApplication.Features.Customers.Handler
{
	public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
	{
		private readonly IApplicationDbContext _context;

		public GetCustomerByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
		{
			var customer = await _context.Customers.FindAsync(request.CustomerID);

			if (customer == null)
			{
				return null; // Müşteri bulunamazsa null döner
			}

			return new CustomerDto
			{
				CustomerID = customer.CustomerID,
				CompanyName = customer.CompanyName,
				IsActive = customer.IsActive
			};
		}
	}
}
