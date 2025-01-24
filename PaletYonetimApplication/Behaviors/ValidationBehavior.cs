using FluentValidation;
using MediatR;

namespace PaletYonetimApplication.Behaviors
{
	public class ValidationBehavior<TRequest, TRespose> : IPipelineBehavior<TRequest, TRespose>
		where TRequest : IRequest<TRespose>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TRespose> Handle(TRequest request, RequestHandlerDelegate<TRespose> next, CancellationToken cancellationToken)
		{
			var context = new ValidationContext<TRequest>(request);

			var failures = _validators
				.Select(v => v.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(f => f != null)
				.ToList();

			if (failures.Count != 0)
			{
				throw new ValidationException(failures);
			}

			return await next();
		}
	}
}
