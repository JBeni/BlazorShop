namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    public class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
    {
        public UpdateSubscriptionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.StripeSubscriptionId)
                .NotEmpty().WithMessage("StripeSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriptionId must not be null");

            RuleFor(x => x.Name)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Options)
                .MaximumLength(1000).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Options must not be empty")
                .NotNull().WithMessage("Options must not be null");

            RuleFor(x => x.ImageName)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            RuleFor(x => x.ImagePath)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("ImagePath must not be empty")
                .NotNull().WithMessage("ImagePath must not be null");
        }
    }
}
