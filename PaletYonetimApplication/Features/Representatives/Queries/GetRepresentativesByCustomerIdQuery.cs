using MediatR;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Representatives.Queries
{
	public class GetRepresentativesByCustomerIdQuery : IRequest<List<RepresentativeDto>>
	{
		public int CustomerID { get; set; }

		public GetRepresentativesByCustomerIdQuery(int customerId)
		{
			CustomerID = customerId;
		}
	}
}
