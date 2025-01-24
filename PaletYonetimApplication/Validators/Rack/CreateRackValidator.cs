using FluentValidation;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Rack
{
	public class CreateRackDtoValidator : AbstractValidator<RackDto>
	{
		public CreateRackDtoValidator()
		{
			RuleFor(r => r.CorridorNumber)
				.NotEmpty()
				.GreaterThan(0)
				.LessThan(5);

			RuleFor(r => r.Corridor)
				.NotEmpty()
				.Must(c => c == "K" || c == "G");

			RuleFor(r => r.Floor)
				.NotEmpty()
				.GreaterThan(0)
				.LessThan(6);

			RuleFor(r => r.Row)
				.NotEmpty()
				.GreaterThan(0)
				.LessThan(100);

			RuleFor(r => r.UsageType)
				.NotEmpty()
				.Must(u => u == "Kiralık" || u == "Stok"); 
		}
	}
}
