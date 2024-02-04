using Business_logic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.Validators
{
	internal class EditAdsModelValidator : AbstractValidator<EditAdsDTO>
	{
		public EditAdsModelValidator()
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
			RuleFor(x => x.UserId)
				.NotEmpty();
		}
	}
}
