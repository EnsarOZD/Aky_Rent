using MediatR;
using Microsoft.EntityFrameworkCore;
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
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllProductsQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			var products = await _context.Products
				.Select(product => new ProductDto
				{
					ProductID=product.ProductID,
					Name=product.Name,
					Barcode=product.Barcode,
					Description=product.Description,
					Unit=product.Unit.ToString(),
					CategoryID=product.CategoryID,
					CustomerStockCode=product.CustomerStockCode,
					CreatedTime=product.CreatedTime,
					UpdatedTime=product.UpdatedTime
				})
				.ToListAsync(cancellationToken);

			return products;
		}
	}
}
