using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Users.Commands
{
	public class DeleteUserCommand : IRequest<bool>
	{
		public int UserID { get; set; }

		public DeleteUserCommand(int userId)
		{
			UserID = userId;
		}
	}
}
