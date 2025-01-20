using MediatR;
using PaletYonetimApplication.Features.Racks.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Racks.Handler
{
	public class DeleteRacksCommandHandler : IRequestHandler<DeleteRackCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteRacksCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(DeleteRackCommand request, CancellationToken cancellationToken)
		{
			var rack = await _context.Racks.FindAsync(request.RackID);

			if (rack == null)
				return false;

			_context.Racks.Remove(rack);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
