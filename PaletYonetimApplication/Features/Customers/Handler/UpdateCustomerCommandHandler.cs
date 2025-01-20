using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Customers.Commands;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Customers.Handler
{
	public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateCustomerCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(UpdateCustomerCommand request,CancellationToken cancellationToken)
		{
			var customer = await _context.Customers.FindAsync(request.CustomerID);

			if (customer==null)
			{
				return false;
			}

			customer.CompanyName = request.CompanyName;
			customer.IsActive = request.IsActive;

			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
	
}
