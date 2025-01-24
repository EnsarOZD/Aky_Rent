using FluentValidation;
using PaletYonetimApplication.Features.Transactions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Validators.Transaction
{
	public class CreateTransactionValidator :AbstractValidator<CreateTransactionCommand>
	{
        public CreateTransactionValidator()
        {
			RuleFor(t => t.PalletID)
			   .NotEmpty() 
			   .GreaterThan(0); 

			RuleFor(t => t.ActionType)
				.NotEmpty() 
				.MaximumLength(50); 

			RuleFor(t => t.Date)
				.NotEmpty() 
				.LessThanOrEqualTo(DateTime.Now); 

			RuleFor(t => t.UserID)
				.NotEmpty() 
				.GreaterThan(0); 
		}
    }
}
