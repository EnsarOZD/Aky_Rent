using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Transactions.Commands
{
	public class DeleteTransactionCommand : IRequest<bool>
	{
		public int TransactionID { get; set; }

		public DeleteTransactionCommand(int transactionId)
		{
			TransactionID = transactionId;
		}
	}
}
