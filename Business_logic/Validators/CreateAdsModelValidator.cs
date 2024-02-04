using FluentValidation;
using Business_logic.DTOs;

namespace Business_logic.Validators
{
    public class CreateAdsModelValidator : AbstractValidator<CreateAdsDTO>
	{
		public CreateAdsModelValidator()
		{
			RuleFor(x => x.Price)
				.NotEmpty()
				.GreaterThanOrEqualTo(0);

			RuleFor(x => x.Description)
				.Length(10, 4000);

			RuleFor(x => x.Title)
				.NotEmpty()
				.MinimumLength(2)
				.Matches(@"[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

			RuleFor(x => x.CategoryId)
				.NotEmpty();
			RuleFor(x => x.Pictures)
				.NotNull()
				.NotEmpty();
		}
	}
}
