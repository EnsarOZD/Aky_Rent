using FluentValidation;
using PaletYonetimApplication.Features.Pallets.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Pallet
{
	public class UpdatePalletValidator :AbstractValidator<UpdatePalletCommand>
	{
        public UpdatePalletValidator()
        {
			RuleFor(p => p.PalletID)
			  .NotEmpty()
			  .GreaterThan(0);

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
