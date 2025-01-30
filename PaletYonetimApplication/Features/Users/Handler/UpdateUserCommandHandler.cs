using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Features.Users.Commands;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Users.Handler
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateUserCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(UpdateUserCommand request,CancellationToken cancellationToken)
		{
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.UserID == request.UserID, cancellationToken);
			if (user == null)
				throw new NotFoundException($"User with ID {request.UserID} was not found.");

			user.FirstName = request.FirstName;
			user.LastName = request.LastName;
			user.Email = request.Email;
			user.Password = request.Password;
			user.RoleID = request.RoleID;

			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}
	}
}
