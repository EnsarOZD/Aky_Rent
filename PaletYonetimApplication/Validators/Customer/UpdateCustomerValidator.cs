using FluentValidation;
using PaletYonetimApplication.Features.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Customer
{
	public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
	{
		public UpdateCustomerValidator()
		{
			RuleFor(c => c.CustomerID)
				.GreaterThan(0);

			RuleFor(c => c.CompanyName)
				.NotEmpty()
				.MaximumLength(100);

			RuleFor(c => c.IsActive)
				.NotNull();
		}
	}
}
