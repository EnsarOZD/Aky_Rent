using FluentValidation;
using PaletYonetimApplication.Features.StockMovements.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.StockMovement
{
	public class UpdateStockMovementValidator:AbstractValidator<UpdateStockMovementCommand>
	{
        public UpdateStockMovementValidator()
        {
			RuleFor(sm => sm.StockMovementID)
				.NotEmpty()
				.GreaterThan(0); 

			RuleFor(sm => sm.PalletID)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(sm => sm.TransactionID)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(sm => sm.ProductID)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(sm => sm.Quantity)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(sm => sm.Note)
				.MaximumLength(500);

		}
    }
}
