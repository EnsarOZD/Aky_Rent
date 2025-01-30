namespace PaletYonetimApplication.Exceptions
{
	public class ValidationException : Exception
	{
		public IEnumerable<FluentValidation.Results.ValidationFailure> Errors { get; }

		public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> errors)
			: base("Validation failed.")
		{
			Errors = errors;
		}
	}
}
