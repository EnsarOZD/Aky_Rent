using MediatR;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Pallets.Commands
{
	public class CreatePalletCommand : IRequest<int>
	{
		public int RackID { get; set; } 
		public int? CustomerID { get; set; } 
		public string Status { get; set; }
	}
}
