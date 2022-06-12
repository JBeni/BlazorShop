namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteSubscriptionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
