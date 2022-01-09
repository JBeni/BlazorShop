namespace BlazorShop.Application.Validators.ProductValidator
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.Price).GreaterThan(0);
        }
    }
}
