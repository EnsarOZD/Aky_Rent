using MediatR;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Products.Queries
{
	public class GetProductByIdQuery: IRequest<ProductDto>
	{
		public int ProductID { get; set; }
		
		public GetProductByIdQuery(int productId)
		{
			ProductID = productId; 
		}
	}
}
