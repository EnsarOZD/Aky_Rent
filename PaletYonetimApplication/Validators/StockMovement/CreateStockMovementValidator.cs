using FluentValidation;
using PaletYonetimApplication.Features.StockMovements.Commands;
using PaletYonetimDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.StockMovement
{
	public class CreateStockMovementValidator:AbstractValidator<CreateStockMovementCommand>
	{
        public CreateStockMovementValidator()
        {
			RuleFor(sm => sm.PalletID)
				.NotEmpty()
				.GreaterThan(0)
				.WithMessage("Palet ID geçerli olmalıdır.");

			RuleFor(sm => sm.TransactionID)
				.NotEmpty() 
				.GreaterThan(0)
				.WithMessage("İşlem ID geçerli olmalıdır."); 

			RuleFor(sm => sm.ProductID)
				.NotEmpty() 
				.GreaterThan(0)
				.WithMessage("Ürün ID geçerli olmalıdır."); 

			RuleFor(sm => sm.Quantity)
				.NotEmpty() 
				.GreaterThan(0)
				.WithMessage("Miktar 0'dan büyük olmalıdır.");

			RuleFor(sm => sm.MovementType)
				.NotEmpty()
				.Must(BeValidMovementType)
				.WithMessage("Geçerli bir hareket türü seçilmelidir.");

			RuleFor(sm => sm.MovementReason)
				.NotEmpty()
				.Must(BeValidMovementReason)
				.WithMessage("Geçerli bir hareket nedeni seçilmelidir.");

			RuleFor(sm => sm.Note)
				.MaximumLength(500)
				.WithMessage("Not en fazla 500 karakter olabilir.");

			RuleFor(sm => sm.ReferenceNumber)
				.MaximumLength(100)
				.WithMessage("Referans numarası en fazla 100 karakter olabilir.");

			RuleFor(sm => sm.ScannedBarcode)
				.MaximumLength(50)
				.WithMessage("Taranan barkod en fazla 50 karakter olabilir.");

			RuleFor(sm => sm.ScannedQRCode)
				.MaximumLength(200)
				.WithMessage("Taranan QR kod en fazla 200 karakter olabilir.");
		}

		private bool BeValidMovementType(string movementType)
		{
			return Enum.TryParse<MovementType>(movementType, out _);
		}

		private bool BeValidMovementReason(string movementReason)
		{
			return Enum.TryParse<MovementReason>(movementReason, out _);
		}
    }
}
