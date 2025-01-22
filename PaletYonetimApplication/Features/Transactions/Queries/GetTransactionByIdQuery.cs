using MediatR;
using PaletYonetimApplication.DTO;

namespace PaletYonetimApplication.Features.Transactions.Queries
{
	public class GetTransactionByIdQuery : IRequest<TransactionDto>
	{
		public int TransactionID { get; set; }

		public GetTransactionByIdQuery(int transactionId)
		{
			TransactionID = transactionId;
		}
	}
}
