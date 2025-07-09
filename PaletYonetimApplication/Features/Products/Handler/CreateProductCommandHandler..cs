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
			if (!Enum.TryParse<ProductUnit>(request.Unit, out var unit))
				throw new FluentValidation.ValidationException("Unit değeri geçersiz! Sadece: Adet, Kg, Litre, Çift, Paket, Koli kullanılabilir.");

			var product = new ProductEntity
			{
				Name = request.Name,
				Barcode = request.Barcode,
				QRCode = request.QRCode,
				Description = request.Description,
				Unit = unit,
				CategoryID = request.CategoryID,
				CustomerStockCode = request.CustomerStockCode,
				SKU = request.SKU,
				Weight = request.Weight,
				Length = request.Length,
				Width = request.Width,
				Height = request.Height,
				MinimumStockLevel = request.MinimumStockLevel ?? 0,
				MaximumStockLevel = request.MaximumStockLevel ?? 1000,
				ReorderPoint = request.ReorderPoint ?? 10,
				ExpiryDate = request.ExpiryDate,
				LotNumber = request.LotNumber,
				SerialNumber = request.SerialNumber,
				IsHazardous = request.IsHazardous,
				RequiresColdStorage = request.RequiresColdStorage,
				IsActive = request.IsActive
			};

			_context.Products.Add(product);
			await _context.SaveChangesAsync(cancellationToken);

			return product.ProductID;
		}
	}
}
