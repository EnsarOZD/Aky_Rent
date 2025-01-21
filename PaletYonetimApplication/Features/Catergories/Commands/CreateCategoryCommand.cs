using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Catergories.Commands
{
	public class CreateCategoryCommand : IRequest<int>
	{
		public string CatergoryName { get; set; }
		public string Description { get; set; }		
	}
}
