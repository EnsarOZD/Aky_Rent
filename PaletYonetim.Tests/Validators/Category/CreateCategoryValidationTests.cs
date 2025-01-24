using FluentValidation.TestHelper;
using PaletYonetimApplication.Features.Catergories.Commands;
using PaletYonetimApplication.Validators.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetim.Tests.Validators.Category
{
    public class CreateCategoryValidationTests
    {
        private readonly CreateCategoryValidation _validator;

        public CreateCategoryValidationTests()
        {
            _validator = new CreateCategoryValidation();
        }

        [Fact]
        public void Should_Have_Error_When_CategoryName_Is_Empty()
        {
            var command = new CreateCategoryCommand { CategoryName = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Have_Error_When_CategoryName_Is_Too_Short()
        {
            var command = new CreateCategoryCommand { CategoryName = "AB" }; // 2 characters
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Have_Error_When_CategoryName_Is_Too_Long()
        {
            var command = new CreateCategoryCommand { CategoryName = new string('A', 101) }; // 101 characters
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_CategoryName_Is_Valid()
        {
            var command = new CreateCategoryCommand { CategoryName = "Valid Category" };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(c => c.CategoryName);
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Too_Long()
        {
            var command = new CreateCategoryCommand { Description = new string('A', 51) }; // 51 characters
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Description);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Description_Is_Valid()
        {
            var command = new CreateCategoryCommand { Description = "Valid Description" };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(c => c.Description);
        }
    }
}
