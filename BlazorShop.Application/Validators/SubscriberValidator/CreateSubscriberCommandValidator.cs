namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class CreateSubscriberCommandValidator : AbstractValidator<CreateSubscriberCommand>
    {
        public CreateSubscriberCommandValidator()
        {
            RuleFor(x => x.Id).Empty().Null();
            RuleFor(x => x.Status).NotEmpty().NotNull();
            RuleFor(x => x.DateStart).NotEmpty().NotNull();
            RuleFor(x => x.CurrentPeriodEnd).NotEmpty().NotNull();
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.SubscriptionId).GreaterThan(0);
        }
    }
}
