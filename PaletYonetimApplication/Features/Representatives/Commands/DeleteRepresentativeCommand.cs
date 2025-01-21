using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Representatives.Commands
{
	public class DeleteRepresentativeCommand:IRequest<bool>
	{
		public int RepresentativeID { get; set; }

		public DeleteRepresentativeCommand(int representativeId)
		{
			RepresentativeID = representativeId;
		}
	}
}
