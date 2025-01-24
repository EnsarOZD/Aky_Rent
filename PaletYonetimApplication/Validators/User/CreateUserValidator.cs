using FluentValidation;
using PaletYonetimApplication.Features.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.User
{
	public class CreateUserValidator : AbstractValidator<CreateUserCommand>
	{
        public CreateUserValidator()
        {
			RuleFor(u => u.FirstName)
				.NotEmpty() 
				.MaximumLength(50); 

			RuleFor(u => u.LastName)
				.NotEmpty() 
				.MaximumLength(50); 

			RuleFor(u => u.Email)
				.NotEmpty() 
				.EmailAddress(); 

			RuleFor(u => u.Password)
				.NotEmpty() 
				.MinimumLength(6) 
				.MaximumLength(50);

			RuleFor(u => u.RoleID)
				.NotEmpty() 
				.GreaterThan(0);
		}
    }
}
