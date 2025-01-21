using MediatR;
using PaletYonetimApplication.Features.Catergories.Commands;
using PaletYonetimApplication.Features.Customers.Commands;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Catergories.Handler
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateCategoryCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _context.Categories.FindAsync(request.CategoryID);

			if (category == null)
			{
				return false;
			}

			category.CategoryName = request.CategoryName;
			category.CategoryID = request.CategoryID;
			category.Description = request.Description;			
			

			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
}
