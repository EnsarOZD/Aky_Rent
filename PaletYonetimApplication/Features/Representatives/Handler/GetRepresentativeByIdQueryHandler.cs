using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Representatives.Queries;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Representatives.Handler
{
	public class GetRepresentativeByIdQueryHandler : IRequestHandler<GetRepresentativeByIdQuery, RepresentativeDto>
	{
		private readonly IApplicationDbContext _context;

		public GetRepresentativeByIdQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<RepresentativeDto> Handle(GetRepresentativeByIdQuery request, CancellationToken cancellationToken)
		{
			var representative = await _context.Representatives
				.FindAsync(request.RepresentativeId);

			if (representative == null) return null;

			return new RepresentativeDto
			{
				RepresentativeID = representative.RepresentativeID,
				CustomerID = representative.CustomerID,
				UserID = representative.UserID,
				Name = representative.Name,
				Phone = representative.Phone,
				Email = representative.Email,
				IsPrimary = representative.IsPrimary,
				CreatedTime = representative.CreatedTime,
				UpdatedTime = representative.UpdatedTime
			};
		}
	}
}
