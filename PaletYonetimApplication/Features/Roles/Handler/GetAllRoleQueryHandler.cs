using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Roles.Queries;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Roles.Handler
{
	public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<RoleDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllRoleQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
		{
			var roles = await _context.Roles
				.Select(role => new RoleDto
				{
					RoleID = role.RoleID,
					RoleName = role.RoleName.ToString(),
					CreatedTime = role.CreatedTime,
					UpdatedTime = role.UpdatedTime

				})
				.ToListAsync(cancellationToken);

			return roles;
		}
	}
}
