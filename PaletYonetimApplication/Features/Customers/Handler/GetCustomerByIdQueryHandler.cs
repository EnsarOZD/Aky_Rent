using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTOs;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Customers.Queries;
using PaletYonetimApplication.Interfaces;

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
			var customer = await _context.Customers
				.FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID, cancellationToken);

			if (customer == null)
			{
				throw new NotFoundException($"Customer with ID {request.CustomerID} was not found.");
			}

			return new CustomerDto
			{
				CustomerID = customer.CustomerID,
				CompanyName = customer.CompanyName,
				IsActive = customer.IsActive,
				CreatedTime = customer.CreatedTime,
				UpdatedTime = customer.UpdatedTime
			};
		}
	}
}
