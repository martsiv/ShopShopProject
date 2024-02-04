using data_access.Entities;
using FluentValidation;

namespace Business_logic.Validators
{
    public class AdvertisementValidator : AbstractValidator<Advertisement>
	{
		public AdvertisementValidator()
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
			RuleFor(x => x.AdvertisementStatusId)
				.NotEmpty();
			RuleFor(x => x.DeliveryContactInfo)
				.NotEmpty();
			RuleFor(x => x.UserId)
				.NotEmpty();
		}
	}
}
