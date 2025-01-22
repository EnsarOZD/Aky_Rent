using MediatR;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Users.Queries
{
	public class GetUserByIdQuery : IRequest<UserDto>
	{
		public int UserID { get; set; }

		public GetUserByIdQuery(int userId)
		{
			UserID = userId;
		}
	}
}
