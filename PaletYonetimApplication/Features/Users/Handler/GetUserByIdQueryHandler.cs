using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Users.Queries;
using PaletYonetimApplication.Interfaces;
using System.Diagnostics.Metrics;

namespace PaletYonetimApplication.Features.Users.Handler
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
	{
		private readonly IApplicationDbContext _context;

		public GetUserByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<UserDto> Handle(GetUserByIdQuery request,CancellationToken cancellationToken)
		{
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.UserID == request.UserID, cancellationToken);

			if (user == null)
				throw new NotFoundException($"User with ID {request.UserID} was not found.");

			return  new UserDto
			{
				UserID = user.UserID,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Password = user.Password,
				RoleID = user.RoleID
			};
		}
	}
}
