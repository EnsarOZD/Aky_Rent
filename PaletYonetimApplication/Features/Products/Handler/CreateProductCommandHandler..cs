using MediatR;
using PaletYonetimApplication.Features.Products.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.Features.Products.Handler
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
	{
		private readonly IApplicationDbContext _context;


		public CreateProductCommandHandler(IApplicationDbContext context)
		{
			_context = context;

		}

		public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{

			var product = new ProductEntity
			{
				Name = request.Name,
				Barcode = request.Barcode,
				Description = request.Description,
				Unit = Enum.Parse<ProductUnit>(request.Unit),
				CategoryID = request.CategoryID,
				CustomerStockCode = request.CustomerStockCode,

			};

			_context.Products.Add(product);

			await _context.SaveChangesAsync(cancellationToken);

			return product.ProductID;

		}
	}
}
