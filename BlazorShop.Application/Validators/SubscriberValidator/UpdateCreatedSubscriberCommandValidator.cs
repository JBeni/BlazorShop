namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class UpdateCreatedSubscriberCommandValidator : AbstractValidator<UpdateCreatedSubscriberCommand>
    {
        public UpdateCreatedSubscriberCommandValidator()
        {
            RuleFor(x => x.CurrentPeriodStart).NotEmpty().NotNull();
            RuleFor(x => x.CurrentPeriodEnd).NotEmpty().NotNull();
            RuleFor(x => x.CustomerEmail).NotEmpty().NotNull();
            RuleFor(x => x.StripeSubscriberSubscriptionId).NotEmpty().NotNull();
            RuleFor(x => x.HostedInvoiceUrl).NotEmpty().NotNull();
        }
    }
}
