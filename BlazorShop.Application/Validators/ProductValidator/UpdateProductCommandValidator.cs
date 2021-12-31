namespace BlazorShop.Application.Validators.ProductValidator
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.Price).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
