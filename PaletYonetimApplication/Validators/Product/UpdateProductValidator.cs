using FluentValidation;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Product
{
	public class UpdateProductDtoValidator : AbstractValidator<ProductDto>
	{
		public UpdateProductDtoValidator()
		{
			RuleFor(p => p.ProductID)
				.NotEmpty()
				.GreaterThan(0); 

			RuleFor(p => p.Name)
				.NotEmpty()
				.MaximumLength(100);

			RuleFor(p => p.Description)
				.MaximumLength(500);

			RuleFor(p => p.Unit)
				.NotEmpty();

			RuleFor(p => p.CategoryID)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(p => p.CustomerStockCode)
				.MaximumLength(20);
		}
	}
}
