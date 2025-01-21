using MediatR;
using PaletYonetimApplication.Features.Catergories.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Catergories.Handler
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateCategoryCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = new CategoryEntity
			{
				CategoryName = request.CatergoryName,
				Description = request.Description,				
			};

			_context.Categories.Add(category);
			await _context.SaveChangesAsync(cancellationToken);

			return category.CategoryID;
		}
	}
}
