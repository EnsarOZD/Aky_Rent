using MediatR;
using PaletYonetimApplication.Features.Representatives.Commands;
using PaletYonetimApplication.Features.Roles.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Roles.Handler
{
	public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateRoleCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
		{

			var role = new RoleEntity
			{
				RoleName = Enum.Parse<UserRole>(request.RoleName)
				
			};

			_context.Roles.Add(role);
			await _context.SaveChangesAsync(cancellationToken);

			return role.RoleID;
		}
	}
}
