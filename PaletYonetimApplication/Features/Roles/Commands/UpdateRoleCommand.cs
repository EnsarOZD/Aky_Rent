using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Roles.Commands
{
	public class UpdateRoleCommand : IRequest<bool>
	{
		public int RoleID { get; set; }
		public string RoleName { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }

	}
}
