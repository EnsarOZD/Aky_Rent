using MediatR;
using PaletYonetimApplication.Features.Customers.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimApplication.Features.Customers.Handlers
{
	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateCustomerCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = new CustomerEntity
			{
				CompanyName = request.CompanyName,
				IsActive = request.IsActive
			};

			_context.Customers.Add(customer);
			await _context.SaveChangesAsync(cancellationToken);

			return customer.CustomerID;
		}
	}
}
