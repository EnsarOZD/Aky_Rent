using FluentValidation;
using PaletYonetimApplication.Features.Roles.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Role
{
	public class UpdateRoleValidator :AbstractValidator<UpdateRoleCommand>
	{
        public UpdateRoleValidator()
        {
			RuleFor(r => r.RoleID)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(r => r.RoleName)
				.NotEmpty()
				.MaximumLength(50);
		}
    }
}
