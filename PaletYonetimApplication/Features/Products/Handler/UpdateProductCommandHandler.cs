using MediatR;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Products.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Enums;

namespace PaletYonetimApplication.Features.Products.Handler
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateProductCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _context.Products.FindAsync(request.ProductID);

			if (product == null)
			{
				throw new NotFoundException($"Product with ID {request.ProductID} was not found.");
			}

			product.ProductID = request.ProductID;
			product.Name = request.Name;
			product.Barcode = request.Barcode;
			product.Description = request.Description;
			product.Unit = Enum.Parse<ProductUnit>(request.Unit);
			product.CategoryID = request.CategoryID;
			product.CustomerStockCode = request.CustomerStockCode;


			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
}
