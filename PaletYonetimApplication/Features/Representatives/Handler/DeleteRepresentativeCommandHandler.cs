using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Representatives.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Representatives.Handler
{
	public class DeleteRepresentativeCommandHandler : IRequestHandler<DeleteRepresentativeCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public DeleteRepresentativeCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(DeleteRepresentativeCommand request, CancellationToken cancellationToken)
		{
			// Silinecek temsilciyi bul
			var representative = await _context.Representatives
				.FirstOrDefaultAsync(r => r.RepresentativeID == request.RepresentativeID, cancellationToken);

			if (representative == null)
			{
				// Temsilci bulunamadıysa false döndür
				return false;
			}

			// Eğer temsilci Primary ise başka bir temsilciyi Primary yap
			if (representative.IsPrimary)
			{
				var nextRepresentative = await _context.Representatives
					.Where(r => r.CustomerID == representative.CustomerID && r.RepresentativeID != representative.RepresentativeID)
					.FirstOrDefaultAsync(cancellationToken);

				if (nextRepresentative != null)
				{
					nextRepresentative.SetAsPrimary();
				}
			}

			// Temsilciyi sil
			_context.Representatives.Remove(representative);
			await _context.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
