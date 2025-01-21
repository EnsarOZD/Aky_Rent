using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Representatives.Commands;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.Features.Representatives.Handler
{
	public class UpdateRepresentativeCommandHandler : IRequestHandler<UpdateRepresentativeCommand, bool>
	{
		private readonly IApplicationDbContext _context;

		public UpdateRepresentativeCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(UpdateRepresentativeCommand request, CancellationToken cancellationToken)
		{
			// Temsilciyi bul
			var representative = await _context.Representatives
				.FirstOrDefaultAsync(r => r.RepresentativeID == request.RepresentativeID, cancellationToken);

			if (representative == null)
				throw new Exception("Representative not found.");

			// Temsilci bilgilerini güncelle
			representative.Name = request.Name;
			representative.Phone = request.Phone;
			representative.Email = request.Email;
			representative.UserID = request.UserID;

			// Eğer IsPrimary true ise, diğer temsilcileri güncelle
			if (request.IsPrimary)
			{
				// Aynı müşteri için diğer temsilcilerin IsPrimary değerini false yap
				var otherRepresentatives = _context.Representatives
					.Where(r => r.CustomerID == representative.CustomerID && r.RepresentativeID != representative.RepresentativeID);

				foreach (var rep in otherRepresentatives)
				{
					rep.RemovePrimary();
				}

				representative.SetAsPrimary();
			}
			else
			{
				representative.RemovePrimary();

			}

			await _context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}

}
