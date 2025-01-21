using MediatR;
using PaletYonetimApplication.DTO;
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
			var product = await _context.Products.FindAsync(request.ProductID);

			if (product == null)
			{
				return null; 
			}

			return new ProductDto
			{
				ProductID = product.ProductID,
				Name = product.Name,
				Barcode = product.Barcode,
				Description = product.Description,
				Unit = product.Unit.ToString(),
				CategoryID = product.CategoryID,
				CustomerStockCode = product.CustomerStockCode,
				CreatedTime = product.CreatedTime,
				UpdatedTime = product.UpdatedTime
			};
		}
	}
}
