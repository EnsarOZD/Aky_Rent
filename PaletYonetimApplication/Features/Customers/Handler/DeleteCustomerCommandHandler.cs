using MediatR;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Customers.Commands;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Customers.Handler
{
	public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteCustomerCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(DeleteCustomerCommand request,CancellationToken cancellationToken)
		{
			var customer = await _context.Customers.FindAsync(request.CustomerID);

			if (customer == null)
				throw new NotFoundException($"Customer with ID {request.CustomerID} was not found.");

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
