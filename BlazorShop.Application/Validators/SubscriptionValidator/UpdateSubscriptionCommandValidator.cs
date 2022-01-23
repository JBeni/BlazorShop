namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    public class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
    {
        public UpdateSubscriptionCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.StripeSubscriptionId).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Options).NotEmpty().NotNull();
            RuleFor(x => x.ImageName).NotEmpty().NotNull();
            RuleFor(x => x.ImagePath).NotEmpty().NotNull();
        }
    }
}
