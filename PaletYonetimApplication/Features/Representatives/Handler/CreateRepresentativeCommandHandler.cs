using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.Features.Representatives.Commands;
using PaletYonetimApplication.Interfaces;
using PaletYonetimDomain.Entities;

namespace PaletYonetimApplication.Features.Representatives.Handler
{
	public class CreateRepresentativeCommandHandler : IRequestHandler<CreateRepresantiveCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateRepresentativeCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateRepresantiveCommand request, CancellationToken cancellationToken)
		{
			// Mevcut bir Primary Representative var mı?
			bool hasPrimary = await _context.Representatives
				.AnyAsync(r => r.CustomerID == request.CustomerID && r.IsPrimary, cancellationToken);

			// Yeni Representative oluşturuluyor
			var representative = new RepresentativeEntity
			{
				CustomerID = request.CustomerID,
				UserID = request.UserID,
				Name = request.Name,
				Phone = request.Phone,
				Email = request.Email
			};

			// Eğer mevcut bir Primary yoksa bu Representative Primary olarak ayarlanır
			if (!hasPrimary)
			{
				representative.SetAsPrimary();
			}

			_context.Representatives.Add(representative);
			await _context.SaveChangesAsync(cancellationToken);

			return representative.RepresentativeID;
		}
	}
}
