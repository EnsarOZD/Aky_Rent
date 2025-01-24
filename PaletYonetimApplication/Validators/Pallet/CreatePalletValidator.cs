using FluentValidation;
using PaletYonetimApplication.Features.Pallets.Commands;
using PaletYonetimDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Pallet
{
	public class CreatePalletValidator : AbstractValidator<CreatePalletCommand>
	{

        public CreatePalletValidator()
        {
			RuleFor(p => p.RackID)
			   .NotEmpty()
			   .GreaterThan(0);

			RuleFor(p => p.CustomerID)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(p => p.Status)
				.IsInEnum();
		}

    }
}
