using FluentValidation;
using PaletYonetimApplication.Features.Products.Commands;

namespace PaletYonetimApplication.Validators.Product
{
	public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty()
				.MaximumLength(100);

			RuleFor(p => p.Barcode)
				.NotEmpty()
				.MaximumLength(50);

			RuleFor(p => p.QRCode)
				.MaximumLength(200);

			RuleFor(p => p.Description)
				.MaximumLength(500);

			RuleFor(p => p.Unit)
				.NotEmpty();

			RuleFor(p => p.CategoryID)
				.GreaterThan(0);

			RuleFor(p => p.CustomerStockCode)
				.MaximumLength(50);

			RuleFor(p => p.SKU)
				.MaximumLength(50);

			RuleFor(p => p.Weight)
				.GreaterThan(0);

			RuleFor(p => p.Length)
				.GreaterThan(0)
				.When(p => p.Length.HasValue);

			RuleFor(p => p.Width)
				.GreaterThan(0)
				.When(p => p.Width.HasValue);

			RuleFor(p => p.Height)
				.GreaterThan(0)
				.When(p => p.Height.HasValue);

			RuleFor(p => p.MinimumStockLevel)
				.GreaterThanOrEqualTo(0)
				.When(p => p.MinimumStockLevel.HasValue);

			RuleFor(p => p.MaximumStockLevel)
				.GreaterThan(0)
				.When(p => p.MaximumStockLevel.HasValue);

			RuleFor(p => p.ReorderPoint)
				.GreaterThanOrEqualTo(0)
				.When(p => p.ReorderPoint.HasValue);

			RuleFor(p => p.LotNumber)
				.MaximumLength(50);

			RuleFor(p => p.SerialNumber)
				.MaximumLength(50);
		}
	}
}
