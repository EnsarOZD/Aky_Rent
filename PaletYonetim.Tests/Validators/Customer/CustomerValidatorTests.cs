using FluentValidation.TestHelper;
using PaletYonetimApplication.Features.Customers.Commands;
using PaletYonetimApplication.Validators.Customer;
using Xunit;

public class CustomerValidatorTests
{
	private readonly CreateCustomerValidator _createValidator;
	private readonly UpdateCustomerValidator _updateValidator;

	public CustomerValidatorTests()
	{
		_createValidator = new CreateCustomerValidator();
		_updateValidator = new UpdateCustomerValidator();
	}

	// CreateCustomerValidator Tests

	[Fact]
	public void Should_Have_Error_When_CompanyName_Is_Empty_In_CreateCustomer()
	{
		var command = new CreateCustomerCommand { CompanyName = "" };
		var result = _createValidator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(c => c.CompanyName);
	}

	[Fact]
	public void Should_Not_Have_Error_When_CompanyName_Is_Valid_In_CreateCustomer()
	{
		var command = new CreateCustomerCommand { CompanyName = "Valid Company" };
		var result = _createValidator.TestValidate(command);
		result.ShouldNotHaveValidationErrorFor(c => c.CompanyName);
	}


	[Fact]
	public void Should_Not_Have_Error_When_IsActive_Is_Valid_In_CreateCustomer()
	{
		var command = new CreateCustomerCommand { CompanyName = "Valid Company", IsActive = true };
		var result = _createValidator.TestValidate(command);
		result.ShouldNotHaveValidationErrorFor(c => c.IsActive);
	}

	// UpdateCustomerValidator Tests

	[Fact]
	public void Should_Have_Error_When_CustomerID_Is_Invalid_In_UpdateCustomer()
	{
		var command = new UpdateCustomerCommand { CustomerID = 0 };
		var result = _updateValidator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(c => c.CustomerID);
	}

	[Fact]
	public void Should_Not_Have_Error_When_CustomerID_Is_Valid_In_UpdateCustomer()
	{
		var command = new UpdateCustomerCommand { CustomerID = 1 };
		var result = _updateValidator.TestValidate(command);
		result.ShouldNotHaveValidationErrorFor(c => c.CustomerID);
	}

	[Fact]
	public void Should_Have_Error_When_CompanyName_Is_Empty_In_UpdateCustomer()
	{
		var command = new UpdateCustomerCommand { CustomerID = 1, CompanyName = "" };
		var result = _updateValidator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(c => c.CompanyName);
	}

	[Fact]
	public void Should_Not_Have_Error_When_CompanyName_Is_Valid_In_UpdateCustomer()
	{
		var command = new UpdateCustomerCommand { CustomerID = 1, CompanyName = "Valid Company" };
		var result = _updateValidator.TestValidate(command);
		result.ShouldNotHaveValidationErrorFor(c => c.CompanyName);
	}


	[Fact]
	public void Should_Not_Have_Error_When_IsActive_Is_Valid_In_UpdateCustomer()
	{
		var command = new UpdateCustomerCommand { CustomerID = 1, CompanyName = "Valid Company", IsActive = true };
		var result = _updateValidator.TestValidate(command);
		result.ShouldNotHaveValidationErrorFor(c => c.IsActive);
	}
}
