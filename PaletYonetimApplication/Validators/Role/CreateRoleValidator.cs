using FluentValidation;
using PaletYonetimApplication.Features.Roles.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Role
{
	public class CreateRoleValidator :AbstractValidator<CreateRoleCommand>
	{
        public CreateRoleValidator()
        {
			RuleFor(r => r.RoleName)
				.NotEmpty() 
				.MaximumLength(50); 
		}
    }
}
