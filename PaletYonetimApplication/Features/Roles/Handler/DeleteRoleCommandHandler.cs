using MediatR;
using PaletYonetimApplication.Features.Roles.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Roles.Handler
{
	public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteRoleCommandHandler(IApplicationDbContext context)
		{
			_context = context; 
		}

		public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
		{
			var role = await _context.Roles.FindAsync(request.RoleID);

			if (role == null)
				return false;

			_context.Roles.Remove(role);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
