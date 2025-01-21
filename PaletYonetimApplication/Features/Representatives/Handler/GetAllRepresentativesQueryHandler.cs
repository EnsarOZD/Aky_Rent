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
	public class GetAllRepresentativesQueryHandler : IRequestHandler<GetAllRepresentativesQuery, List<RepresentativeDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllRepresentativesQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<RepresentativeDto>> Handle(GetAllRepresentativesQuery request, CancellationToken cancellationToken)
		{
			return await _context.Representatives
				.Select(rep => new RepresentativeDto
				{
					RepresentativeID = rep.RepresentativeID,
					CustomerID = rep.CustomerID,
					UserID = rep.UserID,
					Name = rep.Name,
					Phone = rep.Phone,
					Email = rep.Email,
					IsPrimary = rep.IsPrimary,
					CreatedTime=rep.CreatedTime,
					UpdatedTime=rep.UpdatedTime
				})
				.ToListAsync(cancellationToken);
		}
	}
}
