using MediatR;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Catergories.Queries
{
	public class GetAllCategoryQuery : IRequest<List<CategoryDto>>
	{
	}
}
