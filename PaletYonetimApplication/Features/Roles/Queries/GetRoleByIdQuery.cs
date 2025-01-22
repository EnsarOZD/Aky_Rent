using MediatR;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Roles.Queries
{
	public class GetRoleByIdQuery : IRequest<RoleDto>
	{
		public int RoleId { get; set; }

		public GetRoleByIdQuery(int roleId)
		{
			RoleId = roleId;
		}
	}
}
