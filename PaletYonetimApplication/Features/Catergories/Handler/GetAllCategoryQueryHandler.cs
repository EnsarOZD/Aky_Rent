using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.DTOs;
using PaletYonetimApplication.Features.Catergories.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Catergories.Handler
{
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllCategoryQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
		{
			var categories = await _context.Categories
				.Select(category => new CategoryDto
				{
					CategoryID=category.CategoryID,
					CategoryName=category.CategoryName,
					Description=category.Description,
					CreatedTime=category.CreatedTime,
					UpdatedTime=category.UpdatedTime

				})
				.ToListAsync(cancellationToken);

			return categories;
		}
	}
}
