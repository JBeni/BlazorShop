namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class UpdateSubscriberCommandValidator : AbstractValidator<UpdateSubscriberCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public UpdateSubscriberCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.DateStart)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("DateStart must be greater or equal than Current Date")
                .NotEmpty().WithMessage("DateStart must not be empty")
                .NotNull().WithMessage("DateStart must not be null");

            RuleFor(x => x.CurrentPeriodEnd)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("CurrentPeriodEnd must be greater or equal than Current Date")
                .NotEmpty().WithMessage("CurrentPeriodEnd must not be empty")
                .NotNull().WithMessage("CurrentPeriodEnd must not be null");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId must be greater than 0");

            RuleFor(x => x.SubscriptionId)
                .GreaterThan(0).WithMessage("SubscriptionId must be greater than 0");

            RuleFor(x => x.StripeSubscriptionId)
                .NotEmpty().WithMessage("StripeSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriptionId must not be null");

            RuleFor(x => x.StripeSubscriberSubscriptionId)
                .MaximumLength(500).WithMessage("StripeSubscriberSubscriptionId maximum length exceeded")
                .NotEmpty().WithMessage("StripeSubscriberSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriberSubscriptionId must not be null");
        }
    }
}
