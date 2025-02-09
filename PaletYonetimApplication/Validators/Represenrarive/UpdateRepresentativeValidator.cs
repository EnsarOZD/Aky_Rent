using FluentValidation;
using PaletYonetimApplication.Features.Representatives.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Represenrarive
{
	public class UpdateRepresentativeValidator :AbstractValidator<UpdateRepresentativeCommand>
	{
        public UpdateRepresentativeValidator()
        {
			RuleFor(r => r.RepresentativeID)
				.NotEmpty()
				.GreaterThan(0); 

			RuleFor(r => r.CustomerID)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(x => x.UserID)
				.NotEmpty()
				.WithMessage("UserID cannot be empty.");

			RuleFor(r => r.Name)
				.NotEmpty()
				.MaximumLength(100);

			RuleFor(r => r.Phone)
				.NotEmpty()
				.MaximumLength(15);

			RuleFor(r => r.Email)
				.NotEmpty()
				.EmailAddress();

			RuleFor(r => r.IsPrimary)
				.NotNull();
		}
    }
}
