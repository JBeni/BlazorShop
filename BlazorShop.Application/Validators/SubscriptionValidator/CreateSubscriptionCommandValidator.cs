namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
    {
        public CreateSubscriptionCommandValidator()
        {
            RuleFor(x => x.Id).Equal(0);
            RuleFor(x => x.StripeSubscriptionId).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Options).NotEmpty().NotNull();
        }
    }
}
