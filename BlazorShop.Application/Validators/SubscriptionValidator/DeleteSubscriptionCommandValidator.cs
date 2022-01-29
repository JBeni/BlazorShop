namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        public DeleteSubscriptionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
