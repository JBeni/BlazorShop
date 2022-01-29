namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class DeleteSubscriberCommandValidator : AbstractValidator<DeleteSubscriberCommand>
    {
        public DeleteSubscriberCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
