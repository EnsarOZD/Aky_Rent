using FluentValidation;
using PaletYonetimApplication.Features.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Product
{
	public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty();

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
