using MediatR;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Catergories.Queries
{
	public class GetCategoryByIdQuery : IRequest<CategoryDto>
	{
		public int CategoryID { get; set; }

		public GetCategoryByIdQuery(int categoryId)
		{
			CategoryID = categoryId;
		}
	}
}
