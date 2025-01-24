using FluentValidation;
using PaletYonetimApplication.Features.Catergories.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Categories
{
	public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
	{
        public CreateCategoryValidation()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);


            RuleFor(c => c.Description)
                .MaximumLength(50);
                

		}
    }
}
