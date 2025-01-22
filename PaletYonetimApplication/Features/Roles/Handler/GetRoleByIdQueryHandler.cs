using MediatR;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Catergories.Queries;
using PaletYonetimApplication.Features.Roles.Queries;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Roles.Handler
{
	public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
	{
		private readonly IApplicationDbContext _context;

		public GetRoleByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
		{
			var role = await _context.Roles.FindAsync(request.RoleId);

			if (role == null)
				return null;

			return new RoleDto
				{
					RoleID = role.RoleID,
					RoleName = role.RoleName.ToString(),
					CreatedTime = role.CreatedTime,
					UpdatedTime = role.UpdatedTime
				};			

		}
	}
}
