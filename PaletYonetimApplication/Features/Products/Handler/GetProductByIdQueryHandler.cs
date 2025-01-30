using MediatR;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Pallets.Queries;
using PaletYonetimApplication.Features.Products.Queries;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Products.Handler
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
	{
		private readonly IApplicationDbContext _context;

		public GetProductByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _context.Products.FindAsync(request.ProductID);

			if (entity == null)
			{
				throw new NotFoundException($"Product with ID {request.ProductID} was not found.");
			}

			return new ProductDto
			{
				ProductID = entity.ProductID,
				Name = entity.Name,
				Barcode = entity.Barcode,
				Description = entity.Description,
				Unit = entity.Unit.ToString(),
				CategoryID = entity.CategoryID,
				CustomerStockCode = entity.CustomerStockCode,
				CreatedTime = entity.CreatedTime,
				UpdatedTime = entity.UpdatedTime
			};
		}
	}
}
