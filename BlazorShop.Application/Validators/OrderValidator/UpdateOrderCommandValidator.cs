namespace BlazorShop.Application.Validators.OrderValidator
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
            RuleFor(v => v.OrderDate).NotEmpty().NotNull();
            RuleFor(v => v.LineItems).NotEmpty().NotNull();
            RuleFor(v => v.AmountTotal).GreaterThan(0);
        }
    }
}
