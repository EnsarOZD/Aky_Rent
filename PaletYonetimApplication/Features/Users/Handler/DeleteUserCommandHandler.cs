using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Users.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Users.Handler
{
	public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteUserCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.UserID == request.UserID, cancellationToken);

			if (user == null)
				return false;

			_context.Users.Remove(user);
			await _context.SaveChangesAsync(cancellationToken);

			return true;

		}

	}
}
