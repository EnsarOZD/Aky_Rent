﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Products.Commands
{
	public class DeleteProductCommand: IRequest<bool>
	{
		public int ProductID { get; set; }

		public DeleteProductCommand(int productId)
		{
			ProductID = productId;
		}
	}
}
