using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Features.Transactions.Commands
{
	public class CreateTransactionCommand : IRequest<int>
	{
		public int PalletID { get; set; }
		public string ActionType { get; set; }
		public DateTime Date { get; set; }
		public string UserID { get; set; }
	}
}
