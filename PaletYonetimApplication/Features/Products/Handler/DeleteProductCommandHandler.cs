using MediatR;
using PaletYonetimApplication.Features.Products.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Products.Handler
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteProductCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _context.Products.FindAsync(request.ProductID);

			if (product == null)
				return false;

			_context.Products.Remove(product);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
