using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Roles.Commands
{
	public class DeleteRoleCommand : IRequest<bool>
	{
		public int RoleID { get; set; }

		public DeleteRoleCommand(int roleId)
		{
			RoleID = roleId;
		}
	}
}
