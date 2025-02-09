using FluentValidation;
using PaletYonetimApplication.Features.Representatives.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Represenrarive
{
	public class CreateRepresentativeValidator : AbstractValidator<CreateRepresantiveCommand>
	{
		public CreateRepresentativeValidator()
		{
			RuleFor(r => r.CustomerID)
				.NotEmpty()
				.GreaterThan(0); // CustomerID dolu ve pozitif olmalı

			RuleFor(x => x.UserID)
				.NotEmpty()
				.WithMessage("UserID cannot be empty.");

			RuleFor(r => r.Name)
				.NotEmpty()
				.MaximumLength(100); // Temsilci adı dolu olmalı ve maksimum 100 karakter

			RuleFor(r => r.Phone)
				.NotEmpty()
				.MaximumLength(15); // Telefon numarası dolu olmalı ve maksimum 15 karakter

			RuleFor(r => r.Email)
				.NotEmpty()
				.EmailAddress(); // Email adresi geçerli bir formatta olmalı

		}
	}
}
