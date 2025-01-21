using MediatR;
using PaletYonetimApplication.Features.Catergories.Commands;
using PaletYonetimApplication.Features.Customers.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Catergories.Handler
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteCategoryCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _context.Categories.FindAsync(request.CategoryID);

			if (category == null)
				return false;

			_context.Categories.Remove(category);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
