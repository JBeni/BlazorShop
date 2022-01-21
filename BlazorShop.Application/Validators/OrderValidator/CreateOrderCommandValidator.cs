namespace BlazorShop.Application.Validators.OrderValidator
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
            RuleFor(v => v.OrderDate).NotEmpty().NotNull();
            RuleFor(v => v.LineItems).NotEmpty().NotNull();
            RuleFor(v => v.AmountTotal).GreaterThan(0);
        }
    }
}
