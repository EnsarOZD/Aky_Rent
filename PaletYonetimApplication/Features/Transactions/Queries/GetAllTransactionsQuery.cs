using MediatR;
using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Transactions.Queries
{
	public class GetAllTransactionsQuery : IRequest<List<TransactionDto>>
	{
	}
}
