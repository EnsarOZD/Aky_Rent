using MediatR;
using MediatR;

namespace PaletYonetimApplication.Features.Catergories.Commands
{
	public class DeleteCategoryCommand : IRequest<bool>
	{
		public int CategoryID { get; set; }

		public DeleteCategoryCommand(int categoryId)
		{
			CategoryID = categoryId;
		}
	}
}
