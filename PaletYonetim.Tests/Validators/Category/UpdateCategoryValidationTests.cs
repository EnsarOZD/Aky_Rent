using FluentValidation.TestHelper;
using PaletYonetimApplication.Features.Catergories.Commands;
using PaletYonetimApplication.Validators.Categories;

namespace PaletYonetim.Tests.Validators.Category
{
    public class UpdateCategoryValidationTests
    {
        private readonly UpdateCategoryValidation _validator;

        public UpdateCategoryValidationTests()
        {
            _validator = new UpdateCategoryValidation();
        }

        [Fact]
        public void Should_Have_Error_When_CategoryName_Is_Empty()
        {
            var command = new UpdateCategoryCommand { CategoryName = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Have_Error_When_CategoryName_Is_Too_Short()
        {
            var command = new UpdateCategoryCommand { CategoryName = "AB" }; // 2 characters
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Have_Error_When_CategoryName_Is_Too_Long()
        {
            var command = new UpdateCategoryCommand { CategoryName = new string('A', 101) }; // 101 characters
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_CategoryName_Is_Valid()
        {
            var command = new UpdateCategoryCommand { CategoryName = "Valid Category" };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Too_Long()
        {
            var command = new UpdateCategoryCommand { Description = new string('A', 51) }; // 51 characters
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Description);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Description_Is_Valid()
        {
            var command = new UpdateCategoryCommand { Description = "Valid Description" };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(c => c.Description);
        }
    }

}
