using MediatR;
using PaletYonetimApplication.Features.Users.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimApplication.Features.Users.Handler
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateUserCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = new UserEntity
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Password = request.Password,
				RoleID = request.RoleID

			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync(cancellationToken);

			return user.UserID;

		}
	}
}
