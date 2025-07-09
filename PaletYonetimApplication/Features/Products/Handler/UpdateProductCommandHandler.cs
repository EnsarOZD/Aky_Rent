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
			product.QRCode = request.QRCode;
			product.Description = request.Description;
			product.Unit = Enum.Parse<ProductUnit>(request.Unit);
			product.CategoryID = request.CategoryID;
			product.CustomerStockCode = request.CustomerStockCode;
			product.SKU = request.SKU;
			product.Weight = request.Weight;
			product.Length = request.Length;
			product.Width = request.Width;
			product.Height = request.Height;
			product.MinimumStockLevel = request.MinimumStockLevel ?? 0;
			product.MaximumStockLevel = request.MaximumStockLevel ?? 1000;
			product.ReorderPoint = request.ReorderPoint ?? 10;
			product.ExpiryDate = request.ExpiryDate;
			product.LotNumber = request.LotNumber;
			product.SerialNumber = request.SerialNumber;
			product.IsHazardous = request.IsHazardous;
			product.RequiresColdStorage = request.RequiresColdStorage;
			product.IsActive = request.IsActive;


			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
}
