using MediatR;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Catergories.Commands;
using PaletYonetimApplication.Features.Roles.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Roles.Handler
{
	public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateRoleCommandHandler(IApplicationDbContext context)
		{
			_context = context; // Veri tabanı bağlamını al
		}

		public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
		{
			var role = await _context.Roles.FindAsync(request.RoleID);

			if (role == null)
			{
				return false;
			}

			role.RoleID = request.RoleID;
			role.RoleName = Enum.Parse<UserRole>(request.RoleName);				


			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
}
