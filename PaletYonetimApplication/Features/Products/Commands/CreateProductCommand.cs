using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Products.Commands
{
	public class CreateProductCommand: IRequest<int>
	{
		public string Name { get; set; }
		public string Barcode { get; set; }
		public string Description { get; set; }
		public string Unit { get; set; }
		public int CategoryID { get; set; }
		public string CustomerStockCode { get; set; }
	}
}
