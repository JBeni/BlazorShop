namespace BlazorShop.Application.Validators.CartValidator
{
    public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartCommandValidator()
        {
            RuleFor(v => v.CartId).GreaterThan(0);
            RuleFor(v => v.ClotheId).GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.Price).GreaterThan(0);
            RuleFor(v => v.Quantity).GreaterThan(0);
        }
    }
}
