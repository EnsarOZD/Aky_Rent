using MediatR;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.DTOs;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Catergories.Queries;
using PaletYonetimApplication.Features.Customers.Queries;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Catergories.Handler
{
	public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
	{
		private readonly IApplicationDbContext _context;

		public GetCategoryByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			var category = await _context.Categories.FindAsync(request.CategoryID);

			if (category == null)
			{
				throw new NotFoundException($"Category with ID {request.CategoryID} was not found.");
			}

			return new CategoryDto
			{
				CategoryID=category.CategoryID,
				CategoryName=category.CategoryName,
				Description=category.Description,
				CreatedTime=category.CreatedTime,
				UpdatedTime=category.UpdatedTime

			};
		}
	}
}
