using FluentValidation;
using PaletYonetimApplication.Features.Catergories.Commands;

namespace PaletYonetimApplication.Validators.Categories
{
	public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryCommand>
	{
		public UpdateCategoryValidation()
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
