namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class UpdateSubscriberCommandValidator : AbstractValidator<UpdateSubscriberCommand>
    {
        public UpdateSubscriberCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Status).NotEmpty().NotNull();
            RuleFor(x => x.DateStart).NotEmpty().NotNull();
            RuleFor(x => x.CurrentPeriodEnd).NotEmpty().NotNull();
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.SubscriptionId).GreaterThan(0);
        }
    }
}
