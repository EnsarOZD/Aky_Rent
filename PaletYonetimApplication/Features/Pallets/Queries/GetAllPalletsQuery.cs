using MediatR;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Pallets.Queries
{
	public class GetAllPalletsQuery : IRequest<List<PalletDto>>
	{
	}
}
