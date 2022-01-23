namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class UpdateSubscriberStatusCommandValidator : AbstractValidator<UpdateSubscriberStatusCommand>
    {
        public UpdateSubscriberStatusCommandValidator()
        {
            RuleFor(x => x.StripeSubscriberSubscriptionId).NotEmpty().NotNull();
        }
    }
}
