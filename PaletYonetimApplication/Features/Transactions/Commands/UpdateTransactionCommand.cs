using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Transactions.Commands
{
	public class UpdateTransactionCommand : IRequest<bool>
	{
		public int TransactionID { get; set; }
		public int PalletID { get; set; }
		public string ActionType { get; set; }
		public DateTime Date { get; set; }
		public string UserID { get; set; }
	}
}
