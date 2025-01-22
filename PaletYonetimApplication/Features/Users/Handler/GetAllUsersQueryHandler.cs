using MediatR;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Features.Transactions.Queries;
using PaletYonetimApplication.Features.Users.Queries;
using PaletYonetimApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Users.Handler
{
	public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
	{
		private readonly IApplicationDbContext _context;

        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request,CancellationToken cancellationToken)
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password = u.Password,
                    RoleID = u.RoleID
                }).ToListAsync(cancellationToken);

        }
    }
}
